using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMenu : MonoBehaviour
{
    public void NavigateToScene()
    {
        // Load the scene with the given name
        UnityEngine.SceneManagement.SceneManager.LoadScene("SelectDiceScene");
    }
}
