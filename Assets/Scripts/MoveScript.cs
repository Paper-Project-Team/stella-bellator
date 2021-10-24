using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 1.0f;
    [SerializeField] private float jumpSpeed;
    [Range(0,1)][SerializeField] private float airMod = 0.3f;
    [Range(0,1)][SerializeField] private float crouchMod = 0.3f;
    [SerializeField] private bool airControl = true;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundPos;
    [SerializeField] private Transform ceilingPos;
    [SerializeField] private BoxCollider2D playerCollider; // Larger collider that will disable when crouching

    const float groundedRadius = 0.02f; // Radius of circle to check if character is grounded
    public bool isGrounded; // Is the player grounded?
    const float ceilingRadius = 0.01f; // Radius of circle to check if the ceiling is being touched
    private Rigidbody2D playerCharacter;
    private bool facingRight = true; // Is the player facing right?
    private Vector2 moveDirection = Vector2.zero;
    private SpriteRenderer playerSprite;
    private bool isLanding = false;
    private bool isCrouching = false;
    private bool isMoving = false;
    private bool isJumping = false;
    public GameObject player;
    private Animator animator;
    
    void Start()
    {
        playerCharacter = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    
    private void FixedUpdate()
    {
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isCrouch", isCrouching);
        animator.SetBool("midair", !isGrounded);
        animator.SetBool("isLanding", isLanding);
        animator.SetBool("isJumping", isJumping);
        isJumping = false;
        transform.Rotate(Vector3.zero);
        isLanding = false;
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(groundPos.position.x, groundPos.position.y - 0.18f), groundedRadius, groundLayer);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if(!wasGrounded)
                {
                    isLanding = true;
                }
            }
        }
        Debug.Log(isGrounded);
        
        
    }

    public void Move(float move, bool crouching, bool jumping)
    {
        
        //Checks if the player can stand
        if(!crouching)
        {
            if(Physics2D.OverlapCircle(new Vector2(ceilingPos.position.x, ceilingPos.position.y + 0.18f), ceilingRadius, groundLayer))
            {
                crouching = true;
                isCrouching = true;
            }
            else
            {
                crouching = false;
                isCrouching = false;
            }
        }

        if(isGrounded || airControl)
        {
            if(isGrounded)
            {
                
                if(crouching)
                {
                    isCrouching = crouching;
                    move *= crouchMod;
                    if(playerCollider != null)
                    {
                        playerCollider.size = new Vector2(0.2f, 0.15f);
                        playerCollider.offset = new Vector2(-0.03f, -0.03f);
                    }
                }
                else
                {
                    if(playerCollider != null)
                    {
                        isCrouching = crouching;
                        playerCollider.size = new Vector2(0.2f, 0.25f);
                        playerCollider.offset = new Vector2(-0.03f, 0.02f);
                    }
                }
            }
            else
            {
                move *= airMod;
            }

            Vector2 targetVelocity = new Vector2(move * 10f, playerCharacter.velocity.y);
            if(Math.Abs(playerCharacter.velocity.x) >= maxSpeed)
            {
                targetVelocity = new Vector2(0, playerCharacter.velocity.y);
            }
            playerCharacter.AddForce(targetVelocity);
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
            isMoving = Math.Abs(playerCharacter.velocity.x) > 0;
        }
        
        if(isGrounded && jumping)
        {
            isJumping = true;
            isGrounded = false;
            playerCharacter.AddForce(new Vector2(0f, jumpSpeed));
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
