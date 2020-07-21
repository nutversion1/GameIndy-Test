using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MasterMindGame
{
    public class GuessNumberBlock : MonoBehaviour
    {
        [Range(0, 9)] [SerializeField] int number;
        Text numberText;

        void Awake()
        {
            numberText = transform.Find("Number Text").GetComponent<Text>();
        }

        // Start is called before the first frame update
        void Start()
        {
            UpdateNumberText();
        }

        public void HandleUpButton()
        {
            number++;
            if (number > 9)
            {
                number = 0;
            }

            UpdateNumberText();
        }

        public void HandleDownButton()
        {
            number--;
            if (number < 0)
            {
                number = 9;
            }

            UpdateNumberText();
        }

        public int GetNumber()
        {
            return number;
        }

        private void UpdateNumberText()
        {
            numberText.text = number.ToString();
        }
    }
}

