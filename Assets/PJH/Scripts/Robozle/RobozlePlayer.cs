using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobozlePlayer : MonoBehaviour
{
    public void Move(RobozleType robozleType)
    {
        switch (robozleType)
        {
            case RobozleType.TurnRight:
                Debug.Log("right");
                transform.Rotate(Vector3.up, 90.0f);
                break;
            case RobozleType.TurnLeft:
                Debug.Log("left");
                transform.Rotate(Vector3.up, -90.0f);
                break;
            case RobozleType.GoStraight:
                transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * 120);
                break;
            case RobozleType.Empty:
                RobozleManager.instance.gameOver();
                Debug.Log("empty tile!");
                break;
        }
        if (RobozleManager.instance._Stars.Length <= 0)
        {
            RobozleManager.instance.gameSuccess();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RobozleOutGround"))
        {
            RobozleManager.instance.gameOver();
            Debug.Log("out of ground");
        }
    }

}
