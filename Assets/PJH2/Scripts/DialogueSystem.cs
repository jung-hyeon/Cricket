using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TMP_Text textSentence;
    public Canvas canvas;

    Queue<string> sentences = new Queue<string>();
    Dialogue info;

    public void Begin(Dialogue info)
    {
        this.info = info;
        canvas.transform.gameObject.SetActive(true);
        sentences.Clear();

        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }

    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        textSentence.text = sentences.Dequeue();
    }

    private void End()
    {
        Debug.Log("End");
        textSentence.text = string.Empty;
        canvas.transform.gameObject.SetActive(false);
        // 스테이지 종료하고 창닫기

    }
}
