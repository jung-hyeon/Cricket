using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobozleInput : MonoBehaviour
{
    public RobozleType robozleInputType;

    public void RobozleInputClick()
    {
        RobozleManager.instance.currentType = robozleInputType;
        //���콺�� �� �ڽ��� sprite ǥ���ϱ�
    }
}
