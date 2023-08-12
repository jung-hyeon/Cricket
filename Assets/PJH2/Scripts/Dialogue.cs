using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewDialogue", menuName = "Custom/Dialogue")]
[System.Serializable]
public class Dialogue
{
    public List<string> sentences = new List<string>
    {
        "안녕",
        "하세요",
        "스테이지0",
        "입니다."
    };
}
