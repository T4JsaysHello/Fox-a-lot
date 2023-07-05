using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelect : MonoBehaviour
{

   
    public void PlayGame()
    {
        SceneManager.LoadScene("FOX-A-LOT");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("HOWTOPLAY");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MENU");
    }
    
}
