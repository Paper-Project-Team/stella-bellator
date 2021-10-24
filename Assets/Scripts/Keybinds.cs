using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text left, right, jump, crouch, shoot, use, swap1, swap2, swap3;

    private GameObject currentKey;
    [SerializeField] private MoveScript movescript;
    [SerializeField] private ShootingScript shooter;
    private bool isJumping = false;
    private bool isCrouching = false;
    private Animator animator;
    private PlayerWeaponManager manager;
    
    
    private GameObject player;
    

    void Start()
    {
        keys.Add("left", KeyCode.A);
        keys.Add("right", KeyCode.D);
        keys.Add("jump", KeyCode.Space);
        keys.Add("crouch", KeyCode.S);
        keys.Add("shoot", KeyCode.Mouse0);
        keys.Add("use", KeyCode.E);
        /*keys.Add("swap1", KeyCode.Alpha1);
        keys.Add("swap2", KeyCode.Alpha2);
        keys.Add("swap3", KeyCode.Alpha3);

        left.text = keys["left"].ToString();
        right.text = keys["right"].ToString();
        jump.text = keys["jump"].ToString();
        crouch.text = keys["crouch"].ToString();
        use.text = keys["use"].ToString();*/
        movescript = GetComponent<MoveScript>();
        manager = GetComponent<PlayerWeaponManager>();
        animator = GetComponent<Animator>();
        shooter = GetComponent<ShootingScript>();
       
        
    }

    void Update()
    {
        animator.SetBool("isShooting", false);
        isJumping = false;
        isCrouching = false;
        if (Input.GetKeyDown(keys["jump"]))
        {
            // Jump
            isJumping = true;
        }
        if (Input.GetKey(keys["crouch"]))
        {
            // Crouch
            isCrouching = true;
        }
        
        if(isJumping)
        {
            // Can't crouch while jumping
            isCrouching = false;
        }

        movescript.Move(Input.GetAxis("Horizontal"), isCrouching, isJumping);
        
        
        if (Input.GetKeyDown(keys["use"]))
        {
            // Move right
        }
        /*if (Input.GetKeyDown(keys["swap1"]))
        {
            manager.Swap(1); 
        }
        if (Input.GetKeyDown(keys["swap2"]))
        {
            manager.Swap(2);
        }
        if (Input.GetKeyDown(keys["swap3"]))
        {
            manager.Swap(3);
        }
        */
        if (Input.GetKeyDown(keys["shoot"]))
        {
            // Shoot
            animator.SetBool("isShooting", true);
            shooter.Shoot();
        }
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }
}