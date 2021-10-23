using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    
    public int level;
    public int health;
    public float[] position; // Modified name of checkpoint. If player quits without getting to the next checkpoint, then it reloads previous checkpoint.

    public PlayerData(Player player){
        level = player.level;
        health = player.health;

        position = new float[2]; // x, y
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
    }
}
