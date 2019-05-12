using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame ()
    {
        // Debug.Log is used to see if the quit command works properly in the unity console
        Debug.Log("Quitting game...");
        // Application.Quit is used to quit the game when in use
        Application.Quit();
    }
}