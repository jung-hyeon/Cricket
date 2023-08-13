using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage0 : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField input1;
    [SerializeField]
    private TMP_InputField input2;
    [SerializeField]
    private TMP_InputField input3;

    private string correctAnswer1 = "코코아";
    private string correctAnswer2 = "농장";
    private string correctAnswer3 = "노예";

    [SerializeField]
    private GameObject PuzzlePopUp1;
    [SerializeField]
    private GameObject PopUp1;
    [SerializeField]
    private GameObject PopUp2;
    [SerializeField]
    private GameObject PopUp3;


    [SerializeField]
    private GameObject sawImage;

    [SerializeField] private Button Dialogue0;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.openSceneNumber = 0;

        PopUp2.SetActive(false);
        PopUp3.SetActive(false);


        Dialogue0.onClick.Invoke();
    }

    void Update()
    {
    }

   



    public void CheckAnswers()
    {
        if (input1.text == correctAnswer1 && input2.text == correctAnswer2 && input3.text == correctAnswer3)
        {
            // 정답입니다! 다음 단계로 넘어갑니다.
            // 예: 씬 로드, 팝업 표시 등.
            Debug.Log("모든 정답이 맞습니다!");
            PopUp2.SetActive(false);
            PopUp3.SetActive(true);
        }
        else
        {
            // 틀린 답입니다.
            Debug.Log("틀린 답이 있습니다.");
        }
    }
    public void ClickLock()
    {
        PopUp2.SetActive(true);
    }
    public void ClickBack()
    {
        PuzzlePopUp1.SetActive(false);
     
    }
    public void ClickBack2()
    {
        sawImage.SetActive(false);
        Debug.Log("입력");

    }


}
