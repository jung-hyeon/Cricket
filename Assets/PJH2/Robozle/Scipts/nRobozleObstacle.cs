using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nRobozleObstacle : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RobozlePlayer"))
        {
            nRobozleManager.instance.gameOver();
        }

    }
}
