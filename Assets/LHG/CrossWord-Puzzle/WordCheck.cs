using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Word
{
    public class WordCheck : MonoBehaviour
    {
        [SerializeField] private Desired_Word word;
        [SerializeField] private Image img;
        [SerializeField] private InputField inputField;
        int i;
        int j;
        public GameObject[] gameobj;
        public Image[] objImg;

        private void Awake()
        {
            inputField.characterLimit = 1;
            inputField.onSubmit.AddListener(TextCheckHandler);
        }
        private void TextCheckHandler(string arg0)
        {
            if(arg0 == word.UpperCase)
            {
                img.color = Color.green;
                gameobj = GameObject.FindGameObjectsWithTag("Word");
                foreach (GameObject obj in gameobj)
                {
                    objImg[i] = obj.GetComponent<Image>();
                    i++;
                }
                i = 0;
                if (j == 33)
                {
                    for (int i = 0; i < 33; i++)
                    {
                        if (objImg[i].color == Color.green)
                            objImg[i] = null;
                    }
                    if (objImg == null)
                        Debug.Log("complete");
                    else
                        Debug.Log("try");
                    j = 0;
                }
                return;
            }
            img.color = Color.red;
        }
    }
}
