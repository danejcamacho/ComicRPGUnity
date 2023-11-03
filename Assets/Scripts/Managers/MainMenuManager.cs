using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    PauseMenuManager pauseMenuManager;

    private void Start() {
        
    }



    public void PlayGame(){
        SceneManager.LoadScene("Overworld");
        

    }

    public void QuitGame(){
        Application.Quit();        
    }
}
