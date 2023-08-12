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
                return;
            }
            img.color = Color.red;
        }
    }
}
