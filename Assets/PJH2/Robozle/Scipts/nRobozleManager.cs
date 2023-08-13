using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public enum nRobozleType
{
    TurnRight,
    TurnLeft,
    GoStraight,
    Empty,
}

public enum nDirection
{
    UP, RIGHT, DOWN, LEFT,
}

public class nRobozleManager : Singleton<nRobozleManager>
{
    public nRobozlePlayer _player;
    public nDirection playerdirection;
    public nRobozleStar[] _Stars;

    public nRobozleType currentType = nRobozleType.Empty;

    public Sprite[] Robozlemages;

    public GameObject panel;

    public nRobozle[] answers;
    public UnityEngine.UI.Button Exitbutton;

    private int index = 0;
    public TextMeshProUGUI text;

    public float initX, initY;



    public void RobozlePlay()
    {
        if (index >= answers.Length)
        {
            gameSuccess();
            return;
        }
        _player.Move(answers[index].robozleType);
        index++;


    }

    public void ExitButtonClick()
    {
        transform.parent.gameObject.SetActive(false);
    }


    public void gameOver()
    {
        _player.rectTransform.anchoredPosition = new Vector2(initX, initY); // (0, 0)으로 위치 재설정
        index = 0;
        StartCoroutine(ActivateAndDeactivateCoroutine());
        //Debug.Log("game over");
    }

    private IEnumerator ActivateAndDeactivateCoroutine()
    {
        // 게임 오브젝트 활성화
        text.gameObject.SetActive(true);

        // 3초 기다림
        yield return new WaitForSeconds(3.0f);

        // 게임 오브젝트 비활성화
        text.gameObject.SetActive(false);
    }

    public void gameSuccess()
    {
        Exitbutton.gameObject.SetActive(true);
        Debug.Log("game success");
    }




}
