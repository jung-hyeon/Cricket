using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearCheck : MonoBehaviour
{
    public GameObject[] wordObject;
    public Image[] image;
    int i = 0;

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
        Debug.Log(image);
        for (int i = 0; i < image.Length; i++)
        {
            if (image[i].color == Color.green)
                image[i] = null;
        }
        for (int i = 0; i < image.Length; i++)
        {
            if (image == null)
                Debug.Log("Clear");
            else
                Debug.Log("Write");
        }
    }
}
