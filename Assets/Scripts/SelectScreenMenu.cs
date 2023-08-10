using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectScreenMenu : MonoBehaviour
{
    public void Apply(){}

    public void NavigateBack()
    {
        // Load the scene with the given name
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
