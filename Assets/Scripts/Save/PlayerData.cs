using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    
    public string level;

    public PlayerData(Player player){
        level = player.level;
    }
}
