using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScreenMenu : MonoBehaviour
{
    public void Apply(){
        Debug.Log("D4 is selected " + DiceChooser.D4 + " times\n");
        Debug.Log("D6 is selected " + DiceChooser.D6 +" times\n");
        Debug.Log("D8 is selected " + DiceChooser.D8 +" times\n");
        Debug.Log("D10 is selected " + DiceChooser.D10 +" times\n");
        Debug.Log("D12 is selected " + DiceChooser.D12 +" times\n");
        Debug.Log("D20 is selected " + DiceChooser.D20 +" times\n");
        Debug.Log("D100 is selected " + DiceChooser.D100 +" times\n");
        Debug.Log("D% is selected " + DiceChooser.Dpercent +" times\n");
    }

    public void NavigateBack()
    {
        // Load the scene with the given name
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
