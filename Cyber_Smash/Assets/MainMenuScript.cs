using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        sceneManager.LoadScene(sceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.quit();
    }
}
