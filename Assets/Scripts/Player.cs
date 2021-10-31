using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private int health = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage, GameObject player)
    {
        health -= damage;
        if(health <= 0)
        {
            SceneManager.LoadScene("Menu");
            Destroy(player.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
