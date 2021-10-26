using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int health = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(this);
            SceneManager.LoadScene("Menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
