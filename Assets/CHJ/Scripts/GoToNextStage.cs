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
    private GameObject Stage2MainPuzzle1;
    [SerializeField]
    private GameObject Stage2MainPuzzle2;


    [SerializeField]
    private GameObject goToNextStageBtn;


    [SerializeField] private Button Dialogue1;
    [SerializeField] private Button Dialogue2;



    // �� �̵��� ���õ� �Լ�
    public void GoToNextScene()
    {
        if (GameManager.instance.openSceneNumber == 0)
        {
            Stage0.SetActive(false);
            Stage1.SetActive(true);
            GameManager.instance.openSceneNumber++;
            StartCoroutine(Fade.instance.FadeInStart());
            Inventory.instance.ResetItem();
            StartCoroutine(Shit());

            Dialogue1.onClick.Invoke();
        }
        else if (GameManager.instance.openSceneNumber == 1)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(true);
            GameManager.instance.openSceneNumber++;
            StartCoroutine(Fade.instance.FadeInStart());
            Inventory.instance.ResetItem();

            Dialogue2.onClick.Invoke();
            Stage2MainPuzzle1.SetActive(true);
        }

        else if (GameManager.instance.openSceneNumber == 2)
        {
            //StartCoroutine(Fade.instance.FadeInStart());
            GameManager.instance.openSceneNumber++;
            SceneManager.LoadScene("EndScene");

        }
    }

    public void GotoEnd()
    {
        SceneManager.LoadScene("EndScene");
    }
    // ���������� Ŭ���� �ϴ� ������Ʈ�� ȹ������ ��
    // ���� ���������� ���� ��ư�� Ȱ��ȭ �Ǵ� �Լ�
    public void ActiveGoToNextStageBtn()
    {
        goToNextStageBtn.SetActive(true);
    }

    public void GotoMainPuzzle2()
    {
        Stage2MainPuzzle2.SetActive(true);
    }
    IEnumerator Shit()
    {
        Slot.remove = true;
        yield return new WaitForFixedUpdate();

        Slot.remove = false;
    }
}
