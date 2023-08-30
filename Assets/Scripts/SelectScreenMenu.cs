using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectScreenMenu : MonoBehaviour
{

    public static int[] dices = new int[6];

    public void Apply(){
        dices[0] = DiceChooser.d4;
        dices[1] = DiceChooser.d6;
        dices[2] = DiceChooser.d8;
        dices[3] = DiceChooser.d10;
        dices[4] = DiceChooser.d12;
        dices[5] = DiceChooser.d20;
        
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    

    public void NavigateBack()
    {
        // Load the scene with the given name
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
