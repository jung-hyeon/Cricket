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
        //���콺�� �� �ڽ��� sprite ǥ���ϱ�
    }
}
