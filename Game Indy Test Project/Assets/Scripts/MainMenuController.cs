using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void HandleMasterMindGameButton()
    {
        Utility.GoToScene("Master Mind Game");
    }

    public void HandleFindDecimalValueProgramButton()
    {
        Utility.GoToScene("Find Decimal Value Program");
    }

    public void HandlePermutationProgramButton()
    {
        Utility.GoToScene("Permutation Program");
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }
}
