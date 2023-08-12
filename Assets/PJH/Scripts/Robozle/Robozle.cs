using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robozle : MonoBehaviour
{
    public RobozleType robozleType = RobozleType.Empty;
    public Image imageComponent;

    public void setType()
    {
        robozleType = RobozleManager.instance.currentType;
        imageComponent.sprite = RobozleManager.instance.Robozlemages[(int)robozleType];
    }

}
