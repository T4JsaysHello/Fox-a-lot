using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToggle : MonoBehaviour
{
    private float NormalTimeScale = 1;
    private float PausedTimeScale = 0;
    public bool isPaused = false;
    public GameObject crossHair;
    public GameObject pauseUI;
    public GameObject StatUI;
    void Update()
    {
        if (isPaused == false && Time.timeScale == 0){
            Time.timeScale = NormalTimeScale;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                
                Time.timeScale = NormalTimeScale;
                isPaused = false;
                crossHair.SetActive(true);
                pauseUI.SetActive(false);
                StatUI.SetActive(true);
                
            }
            else
            {
                Time.timeScale = PausedTimeScale;
                isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                crossHair.SetActive(false);
                pauseUI.SetActive(true);
                StatUI.SetActive(false);
            }
        }
    }
}
