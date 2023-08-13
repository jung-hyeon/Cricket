using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToNextStage : MonoBehaviour
{
    [SerializeField]
    private GameObject Stage0;
    [SerializeField]
    private GameObject Stage1;
    [SerializeField]
    private GameObject Stage2;


    [SerializeField]
    private GameObject goToNextStageBtn;

    [SerializeField] private Button PlayDialogueButton2;
    [SerializeField] private Button PlayDialogueButton5;



    // �� �̵��� ���õ� �Լ�
    public void GoToNextScene()
    {
        if (GameManager.instance.openSceneNumber == 0)
        {
            Stage0.SetActive(false);
            Stage1.SetActive(true);
            GameManager.instance.openSceneNumber++;
            StartCoroutine(Fade.instance.FadeInStart());

            PlayDialogueButton2.onClick.Invoke(); // 2��° dialogue

        }
        else if (GameManager.instance.openSceneNumber == 1)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(true);
            GameManager.instance.openSceneNumber++;
            StartCoroutine(Fade.instance.FadeInStart());

            PlayDialogueButton5.onClick.Invoke(); // 5��° dialogue
        }

        else if (GameManager.instance.openSceneNumber == 2)
        {
            StartCoroutine(Fade.instance.FadeInStart());
            SceneManager.LoadScene("EndScene");

        }
    }

    public void GotoEnd()
    {
       
    }
    // ���������� Ŭ���� �ϴ� ������Ʈ�� ȹ������ ��
    // ���� ���������� ���� ��ư�� Ȱ��ȭ �Ǵ� �Լ�
    public void ActiveGoToNextStageBtn()
    {
        goToNextStageBtn.SetActive(true);
    }
}
