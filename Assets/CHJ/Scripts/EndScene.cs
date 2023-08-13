using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    [SerializeField] private Button Dialogue3;

    void Awake()
    {
        Dialogue3.onClick.Invoke();
        StartCoroutine(Fade.instance.FadeInStart());
    }
    public void GoToStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
