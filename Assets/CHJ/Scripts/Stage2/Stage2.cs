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

        /*
        Stage2PuzzlePopUp.SetActive(true);
        PuzzlePopUp2.SetActive(false);*/

    }

    void OnEnable()
    {
        
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
