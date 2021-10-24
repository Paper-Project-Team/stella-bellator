using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    [SerializeField] private int damage = 25;
    [SerializeField] private float timeToDestroy = 2;
    private MoveScript mover;

    void Start()
    {
        mover = GameObject.FindWithTag("Player").GetComponent<MoveScript>();
        Bullet(mover.facingRight);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Bullet(bool isFacingRight)
    {
        Rigidbody2D[] list = GetComponentsInChildren<Rigidbody2D>();
        Rigidbody2D rb = list[0];
        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed * 10f, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed * 10f, 0);
        }
        Destroy(gameObject, timeToDestroy);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other);
        other.gameObject.BroadcastMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }
}
