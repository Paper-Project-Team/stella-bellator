using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    
    public int level = 2;
    public int health = 12;

    public void SavePlayer(){
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer(){
        PlayerData data = SaveSystem.LoadPlayer(this);

        level = data.level;
        health = data.health;

        Vector2 position;
        position.x = data.position[0];
        position.y = data.position[1];
        transform.position = position;
    }

      public void RestartLostGame(){
        // Restart Level
      }
}
