using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int openSceneNumber = 0;


    public void GoToGameScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene(0);
    }
}
