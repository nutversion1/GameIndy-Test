using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PermutationProgram
{
    public class GameManager : MonoBehaviour
    {
        List<string> orderList;

        InputField totalInputField;
        Text resultText;

        void Awake()
        {
            totalInputField = GameObject.Find("Total InputField").GetComponent<InputField>();
            resultText = GameObject.Find("Result Text").GetComponent<Text>();
        }

        public void FindValue()
        {
            if (!IsInputValidate())
            {
                return;
            }

            orderList = new List<string>();

            string str = "";

            int totalNum = int.Parse(totalInputField.text);
          
            for (int i = 0; i < totalNum; i++)
            {
                str += i + 1;
            }

            Permute(str, 0, str.Length - 1);

            ShowResult(str);

            ResetScrollPos();
        }

        private void ShowResult(string str)
        {
            //Total order
            resultText.text = "\"" + str + "\"" + " สับเรียงได้ทั้งหมด " + orderList.Count + " รูปแบบ ได้แก่..." + "\n" + "\n";

            //Details
            for (int i = 0; i < orderList.Count; i++)
            {
                resultText.text += orderList[i];

                if (i < orderList.Count - 1)
                {
                    resultText.text += ", ";
                }
            }
        }

        private bool IsInputValidate()
        {
            if (totalInputField.text.Length == 0 || totalInputField.text.Length < 0 || int.Parse(totalInputField.text) < 0)
            {
                return false;
            }

            return true;
        }

        private void Permute(string str, int startIndex, int endIndex)
        {

            if(startIndex == endIndex)
            {
                //Debug.Log(str);
                orderList.Add(str);
            }
            else
            {
                for(int i = startIndex; i <= endIndex; i++)
                { 
                    str = Swap(str, startIndex, i);
                    Permute(str, startIndex + 1, endIndex);
                    str = Swap(str, startIndex, i);
                }
            }
        }

        private string Swap(string str, int aPos, int bPos)
        {
            char temp;
            char[] charArray = str.ToCharArray();
            temp = charArray[aPos];
            charArray[aPos] = charArray[bPos];
            charArray[bPos] = temp;
            string s = new string(charArray);
            return s;
        }

        public void ResetScrollPos()
        {
            resultText.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }

        public void HandleMainMenuButton()
        {
            Utility.GoToScene("Main Menu");
        }
    }
}

