using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MasterMindGame
{
    public class SecretNumberBlock : MonoBehaviour
    {
        int number;
        Text numberText;

        void Awake()
        {
            numberText = transform.Find("Number Text").GetComponent<Text>();
        }

        public void SetNumber(int number)
        {
            this.number = number;
        }

        public int GetNumber()
        {
            return number;
        }

        public void ShowNumber()
        {
            numberText.text = number.ToString();
        }
    }
}

