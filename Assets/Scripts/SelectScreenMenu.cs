using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectScreenMenu : MonoBehaviour
{

    public void Apply()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        DiceChooserManager.dices[0] = DiceChooserManager.d4;
        DiceChooserManager.dices[1] = DiceChooserManager.d6;
        DiceChooserManager.dices[2] = DiceChooserManager.d8;
        DiceChooserManager.dices[3] = DiceChooserManager.d10;
        DiceChooserManager.dices[4] = DiceChooserManager.d12;
        DiceChooserManager.dices[5] = DiceChooserManager.d20;
    }

    public void NavigateBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        DiceChooserManager.d4 = DiceChooserManager.dices[0];
        DiceChooserManager.d6 = DiceChooserManager.dices[1];
        DiceChooserManager.d8 = DiceChooserManager.dices[2];
        DiceChooserManager.d10 = DiceChooserManager.dices[3];
        DiceChooserManager.d12 = DiceChooserManager.dices[4];
        DiceChooserManager.d20 = DiceChooserManager.dices[5];
    }

}
