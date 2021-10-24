using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;
    


    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            Destroy(this);
        }
    }

    void takeDamage(int d)
    {
        health -= d;
    }
}
