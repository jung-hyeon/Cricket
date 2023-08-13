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

    [SerializeField] private GameObject RobozlePopup1;

    [SerializeField] private Button PlayDialogueButton0;
    [SerializeField] private Button PlayDialogueButton1;


    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.openSceneNumber = 0;

        PopUp2.SetActive(false);
        PopUp3.SetActive(false);

        Fade fadeEffect = FindObjectOfType<Fade>();
        StartCoroutine(fadeEffect.FadeInStart());  // 2초 동안 페이드 인

        PlayDialogueButton0.onClick.Invoke(); //0번째 다이얼로그 시작
        StartCoroutine(fadeEffect.FadeOutStart());
    }

    void Update()
    {
        if (AreAllChildrenInactive(gameObject))
        {
            // 모든 자식이 비활성화되었을 때의 작업
            // 예: 다른 게임 오브젝트 호출
            RobozlePopup1.SetActive(true);
        }

    }

    public void ClickLock()
    {
        PopUp2.SetActive(true);
    }

    bool AreAllChildrenInactive(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.gameObject.activeInHierarchy)
                return false;
        }
        return true;
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
    public void ClickBack()
    {
        PuzzlePopUp1.SetActive(false);
     
    }



}
