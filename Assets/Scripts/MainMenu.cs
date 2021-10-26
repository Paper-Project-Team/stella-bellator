using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour{

    // Plays the game from the beginning
    public void NewGame(){
        SceneManager.LoadScene("Hub1");
        PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
    }

    // Plays the game from the last checkpoint saved
    public void LoadGame(){
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene"));
    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }
}
