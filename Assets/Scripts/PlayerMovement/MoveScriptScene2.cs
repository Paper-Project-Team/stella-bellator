using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveScriptScene2 : MonoBehaviour
{
    private float maxSpeed = 5f;
    float jumpSpeed = 10f;
    [Range(0,1)][SerializeField] private float airMod = 0.3f;
    [Range(0,1)][SerializeField] private float crouchMod = 0.3f;
    [SerializeField] private bool airControl = true;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundPos;
    [SerializeField] private Transform ceilingPos;
    [SerializeField] private BoxCollider2D playerCollider; // Larger collider that will disable when crouching

    const float groundedRadius = 0.02f; // Radius of circle to check if character is grounded
    public bool isGrounded = true; // Is the player grounded?
    const float ceilingRadius = 0.01f; // Radius of circle to check if the ceiling is being touched
    private Rigidbody2D playerCharacter;
    public bool facingRight = true; // Is the player facing right?
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

    /*void Update(){
        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * maxSpeed;
    }*/

    void Jump(){
        playerCharacter.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,jumpSpeed), ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        Move(Input.GetAxis("Horizontal"), isCrouching, isJumping);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isCrouch", isCrouching);
        animator.SetBool("midair", !isGrounded);
        animator.SetBool("isLanding", isLanding);
        animator.SetBool("isJumping", isJumping);
        isJumping = false;
        transform.Rotate(Vector3.zero);
        isLanding = false;
        bool wasGrounded = isGrounded;
        if(Input.GetButtonDown("Jump") && isGrounded){
            Jump();
            isGrounded = false;
        }

        /*Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(groundPos.position.x, groundPos.position.y - 0.18f), groundedRadius, groundLayer);
        for(int i = 0; i < colliders.Length; i++)
        {
            Debug.Log("1");
            if(colliders[i].gameObject.transform.position.y < playerCharacter.gameObject.transform.position.y)
            {
                Debug.Log("2");
                isGrounded = true;
                if(!wasGrounded)
                {
                    isLanding = true;
                }
            }
        }*/
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

        transform.Rotate(0f,180f,0f);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.gameObject.layer == 3){
            if(other.gameObject.transform.position.y < playerCharacter.gameObject.transform.position.y){
                isGrounded = true;
            }
        }
    }
}
