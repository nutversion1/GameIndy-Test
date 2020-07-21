using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MasterMindGame
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] bool canGuessSameNumber = true;
        [SerializeField] SecretNumberBlock[] secretNumberBlocks;
        [SerializeField] GuessNumberBlock[] guessNumberBlocks;

        private const int SECRET_NUMBER_TOTAL = 4;

        int[] possibleSecretNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int guessTotal;
        State currentState;
        Text guessTotalText;
        Text outputText;
        Text resultText;
        Button guessButton;
        Button playAgainButton;
        GameObject guessTotalWindow;

        public enum State
        {
            Guess,
            Evaluate,
            End
        }

        void Awake()
        {
            guessButton = GameObject.Find("Guess Button").GetComponent<Button>();
            guessTotalWindow = GameObject.Find("Guess Total Window");
            guessTotalText = GameObject.Find("Guess Total Text").GetComponent<Text>();
            outputText = GameObject.Find("Output Text").GetComponent<Text>();
            resultText = GameObject.Find("Result Text").GetComponent<Text>();
            playAgainButton = GameObject.Find("Play Again Button").GetComponent<Button>();
        }

        // Start is called before the first frame update
        void Start()
        {
            //Init game
            SetSecretNumbers();

            currentState = State.Guess;
            guessTotal = 0;
            playAgainButton.gameObject.SetActive(false);
            resultText.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            switch (currentState)
            {
                case State.Guess:
                    //If "Can Guess Same Number option" is false, then guess button is disable when player try to select the same guess number input value
                    if (!canGuessSameNumber)
                    {
                        if (IsValidInputs())
                        {
                            guessButton.interactable = true;
                        }
                        else
                        {
                            guessButton.interactable = false;
                        }
                    }
                    break;
                case State.Evaluate:
                    break;
            }
        }


        public void HandleGuessButton()
        {
            StartCoroutine(EvaluateGuess());
        }

        private IEnumerator EvaluateGuess()
        {
            currentState = State.Evaluate;

            guessTotal++;
            guessTotalText.text = guessTotal.ToString();

            SetOutput();

            //Delay
            yield return new WaitForSeconds(0);

            currentState = State.Guess;
        }

        private void SetOutput()
        {
            int correctNumberTotal = 0;
            int correctPositionTotal = 0;

            //Get secret numbers & guess numbers
            List<int> secretNumbers = GetSecretNumbers();
            List<int> guessNumbers = GetGuessNumbers();

            //Correct number, then increase correctNumberTotal
            foreach (int guessNumber in guessNumbers)
            {
                if (secretNumbers.Contains(guessNumber))
                {
                    correctNumberTotal++;
                }
            }

            //Correct position, then increase correctPositionTotal 
            for (int i = 0; i < SECRET_NUMBER_TOTAL; i++)
            {
                if (secretNumbers[i] == guessNumbers[i])
                {
                    correctPositionTotal++;
                }
            }

            //Set output text
            outputText.text = "เลขถูก: " + correctNumberTotal + "\n" + "ตำแหน่งถูก: " + correctPositionTotal;

            //End the game
            if (correctPositionTotal == SECRET_NUMBER_TOTAL)
            {
                EndGame();
            }
        }

        public void HandlePlayAgainButton()
        {
            Utility.RestartScene();
        }

        public bool IsValidInputs()
        {
            List<int> guessNumbers = new List<int>();

            foreach (GuessNumberBlock guessNumberBlock in guessNumberBlocks)
            {
                if (guessNumbers.Contains(guessNumberBlock.GetNumber()))
                {
                    return false;
                }

                guessNumbers.Add(guessNumberBlock.GetNumber());
            }

            return true;
        }

        private List<int> GetSecretNumbers()
        {
            List<int> secretNumbers = new List<int>();

            foreach (SecretNumberBlock secretNumberBlock in secretNumberBlocks)
            {
                int secretNumber = secretNumberBlock.GetNumber();
                secretNumbers.Add(secretNumber);
            }

            return secretNumbers;
        }

        private List<int> GetGuessNumbers()
        {
            List<int> guessNumbers = new List<int>();
            foreach (GuessNumberBlock guessNumberBlock in guessNumberBlocks)
            {
                int guessNumber = guessNumberBlock.GetNumber();
                guessNumbers.Add(guessNumber);
            }

            return guessNumbers;
        }

        private void SetSecretNumbers()
        {
            Utility.ShuffleArray(possibleSecretNumbers);

            for (int i = 0; i < SECRET_NUMBER_TOTAL; i++)
            {
                int secretNumber = possibleSecretNumbers[i];

                SecretNumberBlock secretNumberBlock = secretNumberBlocks[i];
                secretNumberBlock.SetNumber(secretNumber);

                Debug.Log(secretNumber);
            }
            Debug.Log("--------------");
        }

        private void EndGame()
        {
            currentState = State.End;

            guessButton.gameObject.SetActive(false);
            playAgainButton.gameObject.SetActive(true);

            foreach (SecretNumberBlock secretNumberBlock in secretNumberBlocks)
            {
                secretNumberBlock.ShowNumber();
            }

            guessTotalWindow.SetActive(false);

            resultText.text = "เก่งมาก! คุณทายถูกจากการทายทั้งหมด " + guessTotal + " ครั้ง";
            resultText.gameObject.SetActive(true);
        }
    }
}

