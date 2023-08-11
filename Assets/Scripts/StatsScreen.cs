using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScreen : MonoBehaviour
{
    public void NavigateToMain()
    {
        Debug.Log("Navigating back to main screen");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

    }
}
