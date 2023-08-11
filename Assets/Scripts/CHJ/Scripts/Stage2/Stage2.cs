using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject Stage2PuzzlePopUp;
    [SerializeField]
    private GameObject PuzzlePopUp2;

    public void GotoPopup2()
    {
        PuzzlePopUp2.SetActive(true);

    }
    public void ClickBack()
    {
        PuzzlePopUp2.SetActive(false);

    }
    
}
