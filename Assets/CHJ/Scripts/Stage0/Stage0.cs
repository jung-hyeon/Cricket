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

    private string correctAnswer1 = "���ھ�";
    private string correctAnswer2 = "����";
    private string correctAnswer3 = "�뿹";

    [SerializeField]
    private GameObject PuzzlePopUp1;
    [SerializeField]
    private GameObject PopUp1;
    [SerializeField]
    private GameObject PopUp2;
    [SerializeField]
    private GameObject PopUp3;
    

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.instance.openSceneNumber = 0;

        PopUp2.SetActive(false);
        PopUp3.SetActive(false);

        Fade fadeEffect = FindObjectOfType<Fade>();
        StartCoroutine(fadeEffect.FadeInStart());  // 2�� ���� ���̵� ��
    }


    public void ClickLock()
    {
        PopUp2.SetActive(true);
    }

    public void CheckAnswers()
    {
        if (input1.text == correctAnswer1 && input2.text == correctAnswer2 && input3.text == correctAnswer3)
        {
            // �����Դϴ�! ���� �ܰ�� �Ѿ�ϴ�.
            // ��: �� �ε�, �˾� ǥ�� ��.
            Debug.Log("��� ������ �½��ϴ�!");
            PopUp2.SetActive(false);
            PopUp3.SetActive(true);
        }
        else
        {
            // Ʋ�� ���Դϴ�.
            Debug.Log("Ʋ�� ���� �ֽ��ϴ�.");
        }
    }
    public void ClickBack()
    {
        PuzzlePopUp1.SetActive(false);
     
    }
}
