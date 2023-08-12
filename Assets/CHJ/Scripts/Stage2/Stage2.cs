using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject Stage2PuzzlePopUp;
    [SerializeField]
    private GameObject PuzzlePopUp2;

    void Awake()
    {
        GameManager.instance.openSceneNumber = 0;

        Stage2PuzzlePopUp.SetActive(false);
        PuzzlePopUp2.SetActive(false);

    }
    public void GotoPopup2()
    {
        Stage2PuzzlePopUp.SetActive(true);

    }
    public void ClickBack()
    {
        PuzzlePopUp2.SetActive(false);

    }
    
}
