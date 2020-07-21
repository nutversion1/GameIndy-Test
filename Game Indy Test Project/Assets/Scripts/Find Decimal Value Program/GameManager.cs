using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FindDecimalValueProgram
{
    public class GameManager : MonoBehaviour
    {
        InputField dividendInputField, divisorInputField, decimalPosInputField;
        Button findButton;
        Text resultText;

        void Awake()
        {
            findButton = GameObject.Find("Find Button").GetComponent<Button>();

            dividendInputField = GameObject.Find("Dividend InputField").GetComponent<InputField>();
            divisorInputField = GameObject.Find("Divisor InputField").GetComponent<InputField>();
            decimalPosInputField = GameObject.Find("Decimal Pos InputField").GetComponent<InputField>();

            resultText = GameObject.Find("Result Text").GetComponent<Text>();
        }

        public void FindValue()
        {
            ////Validation
            if (dividendInputField.text.Length == 0 || divisorInputField.text.Length == 0 || decimalPosInputField.text.Length == 0)
            {
                resultText.text = "กรอกข้อมูลไม่ครบ";
                return;
            }

            if (int.Parse(dividendInputField.text) < 0 || int.Parse(divisorInputField.text) < 0 || int.Parse(decimalPosInputField.text) < 0)
            {
                resultText.text = "ห้ามใส่จำนวนติดลบ";
                return;
            }

            if (divisorInputField.text == 0.ToString())
            {
                resultText.text = "ไม่สามารถหารด้วยเลข 0 ได้";
                return;
            }

            if (decimalPosInputField.text == 0.ToString())
            {
                resultText.text = "ตำแหน่งทศนิยมไม่สามารถเป็น 0 ได้";
                return;
            }

            ////Find result
            //Get values from input fields
            int dividend = int.Parse(dividendInputField.text);
            int divisor = int.Parse(divisorInputField.text);
            int decimalPos = int.Parse(decimalPosInputField.text);

            //Divide
            int quotient = dividend / divisor;
            int remainder = dividend % divisor;

            string decimalStr = "";

            //Have decimal
            if (remainder != 0)
            {

                //Collect decimal value
                int decimalDividend = remainder * 10;

                for (int i = 0; i < decimalPos; i++)
                {
                    int decimalQuotient = decimalDividend / divisor;
                    int decimalRemainder = decimalDividend % divisor;

                    decimalStr += decimalQuotient;

                    if (decimalRemainder == 0)
                    {
                        break;
                    }

                    decimalDividend = decimalRemainder * 10;
                }
            }
            //No decimal
            else
            {
                resultText.text = "ไม่มีจุดทศนิยม";
                Debug.Log(quotient);
                return;
            }

            //Print divided value
            Debug.Log(quotient + "." + decimalStr);

            //Find decimal value in the position
            if(decimalPos - 1 < decimalStr.Length)
            {
                resultText.text = decimalStr[decimalStr.Length - 1].ToString();
            }
            else
            {
                resultText.text = "ตำแหน่งไม่พอหา" + " (มีแค่ " + decimalStr.Length + " ตำแหน่ง)";
                return;
            }
        }
    }
}

