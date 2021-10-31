using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    private float speed = 20f;
    private int damage = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start(){
        rb.velocity = transform.right * speed;
    }

    /*public void OnTriggerEnter2D(Collider2D hitInfo){
        yield return new WaitForSeconds(2);  
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        // If collider = player collider
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }*/

    /*bool isTriggered;
    float waitTime = 5f; 
    void Update () { 
        if (isTriggered == true) {
            waitTime -= Time.deltaTime;
        } 
        if (isTriggered == true && waitTime <= 0f) 
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag == "Player") { 
            //isTriggered = true; 
            Player player = other.GetComponent<Player>();
            player.TakeDamage(damage, player.gameObject);
            Destroy(this.gameObject);
        }
    }
}
