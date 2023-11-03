using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public static bool gameIsPaused = false;
    bool canPause_ = true;
    //public GameObject pauseMenuUI;

    private void Update() {
        if(canPause_ && Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
            
        }
    }


    public void PauseGame(){
        //pauseMenuUI.SetActive(true);
        GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ResumeGame(){
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
        gameIsPaused = false;
        
    }

    public void GoToMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitFromPause(){
        Application.Quit();
    }

    
}
