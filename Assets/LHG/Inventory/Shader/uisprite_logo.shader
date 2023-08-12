// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "uisprite_shine_logo"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
		_MainTex("MainTex", 2D) = "white" {}
		_Tint("Tint", Color) = (1,1,1,1)
		_Uiglow("Uiglow", 2D) = "white" {}
		_Timescale("Timescale", Float) = 2
		_Float1("Float 1", Range( 0 , 1)) = 3.273265
		_Value("Value", Range( 0 , 1)) = 1
		_scale("scale", Float) = 0.47
		_yoffset("yoffset", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}

	}

	SubShader
	{
		LOD 0

		Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "PreviewType"="Plane" "CanUseSpriteAtlas"="True" }
		
		Stencil
		{
			Ref [_Stencil]
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
			CompFront [_StencilComp]
			PassFront [_StencilOp]
			FailFront Keep
			ZFailFront Keep
			CompBack Always
			PassBack Keep
			FailBack Keep
			ZFailBack Keep
		}


		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]

		
		Pass
		{
			Name "Default"
		CGPROGRAM
			
			#ifndef UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX
			#define UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input)
			#endif
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile __ UNITY_UI_CLIP_RECT
			#pragma multi_compile __ UNITY_UI_ALPHACLIP
			
			#include "UnityShaderVariables.cginc"

			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD1;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
				float4 ase_texcoord2 : TEXCOORD2;
			};
			
			uniform fixed4 _Color;
			uniform fixed4 _TextureSampleAdd;
			uniform float4 _ClipRect;
			uniform sampler2D _MainTex;
			uniform float4 _Tint;
			uniform float4 _MainTex_ST;
			uniform float _Float1;
			uniform sampler2D _Uiglow;
			uniform float _scale;
			uniform float _Timescale;
			uniform float _yoffset;
			uniform float _Value;

			
			v2f vert( appdata_t IN  )
			{
				v2f OUT;
				UNITY_SETUP_INSTANCE_ID( IN );
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
				UNITY_TRANSFER_INSTANCE_ID(IN, OUT);
				OUT.worldPosition = IN.vertex;
				float3 ase_worldPos = mul(unity_ObjectToWorld, IN.vertex).xyz;
				OUT.ase_texcoord2.xyz = ase_worldPos;
				
				
				//setting value to unused interpolator channels and avoid initialization warnings
				OUT.ase_texcoord2.w = 0;
				
				OUT.worldPosition.xyz +=  float3( 0, 0, 0 ) ;
				OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

				OUT.texcoord = IN.texcoord;
				
				OUT.color = IN.color * _Color;
				return OUT;
			}

			fixed4 frag(v2f IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				float2 uv_MainTex = IN.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
				float4 tex2DNode3 = tex2D( _MainTex, uv_MainTex );
				float3 ase_worldPos = IN.ase_texcoord2.xyz;
				float2 appendResult165 = (float2(ase_worldPos.x , ase_worldPos.y));
				float mulTime27 = _Time.y * _Timescale;
				float2 appendResult167 = (float2(mulTime27 , _yoffset));
				float4 break163 = ( ( _Tint * tex2DNode3 ) + ( _Float1 * tex2D( _Uiglow, (appendResult165*_scale + appendResult167) ) ) );
				float2 texCoord150 = IN.texcoord.xy * float2( 1,1 ) + float2( 0,0 );
				float temp_output_151_0 = ( texCoord150.y + ( 1.0 - _Value ) );
				float4 appendResult162 = (float4(break163.r , break163.g , break163.b , ( step( temp_output_151_0 , 1.0 ) * ( _Tint.a * tex2DNode3.a ) )));
				
				half4 color = appendResult162;
				
				#ifdef UNITY_UI_CLIP_RECT
                color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                #endif
				
				#ifdef UNITY_UI_ALPHACLIP
				clip (color.a - 0.001);
				#endif

				return color;
			}
		ENDCG
		}
	}
	CustomEditor "ASEMaterialInspector"
	
	
}
/*ASEBEGIN
Version=18800
91;179;1693;1013;845.0227;-1380.194;1;True;False
Node;AmplifyShaderEditor.RangedFloatNode;36;-310.0341,1953.029;Inherit;False;Property;_Timescale;Timescale;3;0;Create;True;0;0;0;False;0;False;2;0.45;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.WorldPosInputsNode;164;-164.942,1100.453;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;169;-23.02271,2002.194;Inherit;False;Property;_yoffset;yoffset;7;0;Create;True;0;0;0;False;0;False;0;-0.37;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;27;-103.8202,1828.248;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;165;105.058,1164.453;Inherit;True;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;168;71.867,1465.385;Inherit;False;Property;_scale;scale;6;0;Create;True;0;0;0;False;0;False;0.47;0.47;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;167;193.6246,1814.191;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;166;379.058,1358.453;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT;1;False;2;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;149;946.5104,62.63131;Inherit;False;Property;_Value;Value;5;0;Create;True;0;0;0;False;0;False;1;1;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;3;-874,128;Inherit;True;Property;_MainTex;MainTex;0;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;158;1318.58,100.3941;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;43;734.2041,974.5363;Inherit;False;Property;_Float1;Float 1;4;0;Create;True;0;0;0;False;0;False;3.273265;0.5;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;150;1055.613,-296.8299;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;1;-769,-106;Inherit;False;Property;_Tint;Tint;1;0;Create;True;0;0;0;False;0;False;1,1,1,1;1,1,1,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;39;667.0334,1231.054;Inherit;True;Property;_Uiglow;Uiglow;2;0;Create;True;0;0;0;False;0;False;-1;3968cb73266d05f47ada3064d0ccf177;3968cb73266d05f47ada3064d0ccf177;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;151;1468.993,-206.1797;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;906.4011,515.5318;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;1241.626,952.7007;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;156;1727.47,197.0488;Inherit;False;Constant;_Float4;Float 4;7;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.StepOpNode;155;1960.277,-111.9688;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-290.8977,177.1404;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;33;1648.36,460.6126;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.BreakToComponentsNode;163;1890.047,581.3569;Inherit;False;COLOR;1;0;COLOR;0,0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;159;1554.395,198.7117;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;162;2297.047,499.357;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.TFHCRemapNode;20;-488.2703,1376.6;Inherit;True;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;160;1718.081,-197.7015;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ViewDirInputsCoordNode;148;33.70996,1622.109;Inherit;False;World;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;152;1492,306.2213;Inherit;False;Constant;_Float0;Float 0;7;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMinOpNode;35;743.8265,1090.459;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;106;1188.307,1170.153;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;161;2786.975,177.7516;Float;False;True;-1;2;ASEMaterialInspector;0;5;uisprite_shine_logo;5056123faa0c79b47ab6ad7e8bf059a4;True;Default;0;0;Default;2;True;2;5;False;-1;10;False;-1;0;1;False;-1;0;False;-1;False;False;False;False;False;False;False;False;True;2;False;-1;True;True;True;True;True;0;True;-9;False;False;False;True;True;0;True;-5;255;True;-8;255;True;-7;0;True;-4;0;True;-6;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;True;2;False;-1;True;0;True;-11;False;True;5;Queue=Transparent=Queue=0;IgnoreProjector=True;RenderType=Transparent=RenderType;PreviewType=Plane;CanUseSpriteAtlas=True;False;0;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;0;;0;0;Standard;0;0;1;True;False;;False;0
WireConnection;27;0;36;0
WireConnection;165;0;164;1
WireConnection;165;1;164;2
WireConnection;167;0;27;0
WireConnection;167;1;169;0
WireConnection;166;0;165;0
WireConnection;166;1;168;0
WireConnection;166;2;167;0
WireConnection;158;0;149;0
WireConnection;39;1;166;0
WireConnection;151;0;150;2
WireConnection;151;1;158;0
WireConnection;4;0;1;0
WireConnection;4;1;3;0
WireConnection;42;0;43;0
WireConnection;42;1;39;0
WireConnection;155;0;151;0
WireConnection;155;1;156;0
WireConnection;6;0;1;4
WireConnection;6;1;3;4
WireConnection;33;0;4;0
WireConnection;33;1;42;0
WireConnection;163;0;33;0
WireConnection;159;0;155;0
WireConnection;159;1;6;0
WireConnection;162;0;163;0
WireConnection;162;1;163;1
WireConnection;162;2;163;2
WireConnection;162;3;159;0
WireConnection;160;0;151;0
WireConnection;161;0;162;0
ASEEND*/
//CHKSM=5B1C6C3D9BB18C884A181080D51E0F65900B3C36