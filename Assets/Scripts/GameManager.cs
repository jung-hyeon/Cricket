using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int openSceneNumber = 0;
    public bool ClearStage0;
    public bool ClearStage1;
    public bool ClearStage2;

    


    public void GoToGameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToEndScene()
    {
        SceneManager.LoadScene(2);
    }
}
