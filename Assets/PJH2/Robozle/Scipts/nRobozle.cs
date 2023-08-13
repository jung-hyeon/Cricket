using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nRobozle : MonoBehaviour
{
    public nRobozleType robozleType = nRobozleType.Empty;
    public Image imageComponent;

    public void setType()
    {
        robozleType = nRobozleManager.instance.currentType;
        imageComponent.sprite = nRobozleManager.instance.Robozlemages[(int)robozleType];
    }

}
