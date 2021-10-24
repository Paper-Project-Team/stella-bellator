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

    [SerializeField] private float groundedRadius = 0.02f; // Radius of circle to check if character is grounded
    public bool isGrounded; // Is the player grounded?
    [SerializeField] private float ceilingRadius = 0.01f; // Radius of circle to check if the ceiling is being touched
    [SerializeField] private float ceilingOffset = 0.0f;
    [SerializeField] private float groundOffset = 0.0f;
    private Rigidbody2D playerCharacter;
    public bool facingRight = true; // Is the player facing right?
    private Vector2 moveDirection = Vector2.zero;
    private SpriteRenderer playerSprite;
    private bool isLanding = false;
    public bool isCrouching = false;
    public bool wasCrouching = false;
    private bool isMoving = false;
    private bool isJumping = false;
    public GameObject player;
    private Animator animator;
    private Vector2 crouchCollider;
    private Vector2 standCollider;
    private GameObject[] objs;


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

        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(groundPos.position.x, groundPos.position.y - groundOffset), groundedRadius, groundLayer);
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
        

        
        

        
    }

    public void Move(float move, bool crouching, bool jumping)
    {
        
        //Checks if the player can stand
        if(!crouching)
        {
            if(Physics2D.OverlapCircle(new Vector2(ceilingPos.position.x, ceilingPos.position.y + ceilingOffset), ceilingRadius, groundLayer))
            {
                wasCrouching = isCrouching;
                crouching = true;
                isCrouching = true;
               
            }
            else
            {
                wasCrouching = isCrouching;
                crouching = false;
                isCrouching = false;
                
            }
            
        }

        if(isGrounded || airControl)
        {
            if(isGrounded)
            {
                wasCrouching = isCrouching;
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

            Vector2 targetVelocity = new Vector2(move * 5f, playerCharacter.velocity.y * 0.5f);
            if(Math.Abs(playerCharacter.velocity.x) >= maxSpeed)
            {
                targetVelocity = new Vector2(0, targetVelocity.y);
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
            playerCharacter.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
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
