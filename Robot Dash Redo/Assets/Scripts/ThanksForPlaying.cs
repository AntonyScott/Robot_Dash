using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThanksForPlaying : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitButton()
    {
        // Debug.Log is used to see if the quit command works properly in the unity console
        Debug.Log("Quitting game...");
        // Application.Quit is used to quit the game when in use
        Application.Quit();
    }
}
