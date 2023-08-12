using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobozleInput : MonoBehaviour
{
    public RobozleType robozleInputType;

    public void RobozleInputClick()
    {
        RobozleManager.instance.currentType = robozleInputType;
        //마우스에 내 자신의 sprite 표시하기
    }
}
