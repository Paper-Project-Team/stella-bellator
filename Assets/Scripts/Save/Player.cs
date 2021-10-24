using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    
    public string level;

    void Update(){
      level = SceneManager.GetActiveScene().name;
      SavePlayer();
    }

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer(this);

        level = data.level;
    }

      public void RestartLostGame(){
        // Restart Level
      }
}
