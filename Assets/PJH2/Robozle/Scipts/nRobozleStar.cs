using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nRobozleStar : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RobozlePlayer"))
        {
            Debug.Log("get Star");
            gameObject.SetActive(false);
        }

    }
}