using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nRobozlePlayer : MonoBehaviour
{
    public RectTransform rectTransform;
    public void Move(nRobozleType robozleType)
    {
        switch (robozleType)
        {
            case nRobozleType.TurnRight:
                rectTransform.Rotate(new Vector3(0f, 0f, -90f));
                break;
            case nRobozleType.TurnLeft:
                rectTransform.Rotate(new Vector3(0f, 0f, 90f));
                break;
            case nRobozleType.GoStraight:
                rectTransform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * 120);
                break;
            case nRobozleType.Empty:
                nRobozleManager.instance.gameOver();
                break;
        }
        if (nRobozleManager.instance._Stars.Length <= 0)
        {
            nRobozleManager.instance.gameSuccess();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RobozleOutGround"))
        {
            nRobozleManager.instance.gameOver();
            Debug.Log("out of ground");
        }
    }

}
