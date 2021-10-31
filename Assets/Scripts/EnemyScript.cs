using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    private int health = 100;

    public float Range;
    public Transform Target; // player
    bool Detected = false;
    Vector2 Direction;
    public GameObject enemy;
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    private int layerMaskPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        layerMaskPlayer = LayerMask.GetMask("Player");
    }
    // Update is called once per frame
    void Update()
    {
        try {
            Vector2 targetPos = Target.position;
            Direction = targetPos - (Vector2)transform.position;
            RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range, layerMaskPlayer);
            if(rayInfo){
                if(rayInfo.collider.gameObject.tag == "Player")
                {
                    if (Detected == false)
                    {
                        Detected = true;
                    }
                }
                else
                {
                    if (Detected == true)
                    {
                        Detected = false;
                    }
                }
            }
            if (Detected)
            {
                //enemy.transform.up = Direction;
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
        catch (MissingReferenceException)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void TakeDamage(int damage, GameObject enemy)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(enemy.gameObject);
        }
    }

    void Shoot(){
        GameObject aBullet = Instantiate(bullet, Shootpoint.position, Shootpoint.rotation);
        Destroy(aBullet, 5);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
