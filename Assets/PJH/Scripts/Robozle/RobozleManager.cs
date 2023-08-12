using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum RobozleType
{
    TurnRight,
    TurnLeft,
    GoStraight,
    Empty,
}

public enum Direction
{
    UP, RIGHT, DOWN, LEFT,
}

public class RobozleManager : Singleton<RobozleManager>
{
    public RobozlePlayer _player;
    public Direction playerdirection;
    public RobozleStar[] _Stars;

    public RobozleType currentType = RobozleType.Empty;

    public Sprite[] Robozlemages;

    public GameObject panel;

    public void RobozlePlay()
    {
        if (panel.transform != null)
        {
            // 패널의 자식 오브젝트들에 접근하고 처리하기
            int childCount = panel.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                //Debug.Log("i는 " + i);
                Transform child = panel.transform.GetChild(i);

                // 자식 오브젝트의 컴포넌트에 접근하여 처리 (예: Text, Image 등)
                Robozle childRobozle = child.GetComponent<Robozle>();
                if (childRobozle != null)
                {
                    //_player.Move(childRobozle.robozleType);
                    //Debug.Log("i는" + i);
                    StartCoroutine(DelayCoroutine(childRobozle.robozleType));
                }
            }
        }
        else
        {
            Debug.LogWarning("Panel transform is not assigned.");
        }
    }

    private IEnumerator DelayCoroutine(RobozleType robozleType)
    {
        yield return new WaitForSeconds(1.0f); // 3초 대기

        _player.Move(robozleType);
        Debug.Log("move move");
        //Debug.Log("Code resumed after delay");
        // 이곳에 3초 후에 실행되어야 할 코드를 추가할 수 있습니다.
    }

    public void gameOver()
    {
        //transform.parent.gameObject.SetActive(false);
        Debug.Log("game over");
    }

    public void gameSuccess()
    {
        Debug.Log("game success");
    }


}
