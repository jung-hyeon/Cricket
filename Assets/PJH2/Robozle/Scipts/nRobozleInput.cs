using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nRobozleInput : MonoBehaviour
{
    public nRobozleType robozleInputType;

    public void RobozleInputClick()
    {
        Debug.Log("input click");
        nRobozleManager.instance.currentType = robozleInputType;
        //마우스에 내 자신의 sprite 표시하기
    }
}
