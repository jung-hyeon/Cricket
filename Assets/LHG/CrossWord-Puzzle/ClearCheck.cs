using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ClearCheck : MonoBehaviour
{
    public GameObject[] wordObject;
    public Image[] image;
    int i = 0;
    bool clear;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
            ColorCheck();
    }

    void ColorCheck()
    {
        Debug.Log("start");
        foreach (GameObject obj in wordObject)
        {
            image[i] = obj.GetComponent<Image>();
            i++;
        }
        i = 0;
        for (int i = 0; i < image.Length; i++)
        {
            clear = false;
            if (image[i].color == Color.green)
            {
                image[i] = null;
                clear = true;
                Debug.Log(i);
                Debug.Log(image.Length);
            }
            if (i == image.Length - 1 && clear)
                Debug.Log("Clear");
        }
    }
}
