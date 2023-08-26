using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectScreenMenu : MonoBehaviour
{

    public static string[] dices = new string[6];

    public void Apply(){
        dices[0] = DiceChooser.D4;
        dices[1] = DiceChooser.D6;
        dices[2] = DiceChooser.D8;
        dices[3] = DiceChooser.D10;
        dices[4] = DiceChooser.D12;
        dices[5] = DiceChooser.D20;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    

    public void NavigateBack()
    {
        // Load the scene with the given name
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
