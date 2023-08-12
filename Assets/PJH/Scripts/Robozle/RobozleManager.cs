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
            // �г��� �ڽ� ������Ʈ�鿡 �����ϰ� ó���ϱ�
            int childCount = panel.transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                //Debug.Log("i�� " + i);
                Transform child = panel.transform.GetChild(i);

                // �ڽ� ������Ʈ�� ������Ʈ�� �����Ͽ� ó�� (��: Text, Image ��)
                Robozle childRobozle = child.GetComponent<Robozle>();
                if (childRobozle != null)
                {
                    //_player.Move(childRobozle.robozleType);
                    //Debug.Log("i��" + i);
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
        yield return new WaitForSeconds(1.0f); // 3�� ���

        _player.Move(robozleType);
        Debug.Log("move move");
        //Debug.Log("Code resumed after delay");
        // �̰��� 3�� �Ŀ� ����Ǿ�� �� �ڵ带 �߰��� �� �ֽ��ϴ�.
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
