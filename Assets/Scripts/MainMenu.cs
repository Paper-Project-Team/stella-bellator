using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{
    // Plays the game from the beginning
    public void NewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Plays the game from the last checkpoint saved
    public void LoadGame(){

    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
