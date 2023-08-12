using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobozleStar : MonoBehaviour
{
    public void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("RobozlePlayer"))
        {
            Debug.Log("get Star");
            gameObject.SetActive(false);
        }
        Debug.Log("******");
    }
}