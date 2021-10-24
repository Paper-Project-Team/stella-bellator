using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Keybinds : MonoBehaviour
{
    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text left, right, jump, crouch, shoot, use;

    private GameObject currentKey;
    [SerializeField] private MoveScript movescript;
    private bool isJumping = false;
    private bool isCrouching = false;

    void Start()
    {
        keys.Add("left", KeyCode.A);
        keys.Add("right", KeyCode.D);
        keys.Add("jump", KeyCode.Space);
        keys.Add("crouch", KeyCode.S);
        keys.Add("shoot", KeyCode.Mouse0);
        keys.Add("use", KeyCode.E);
        /*
        left.text = keys["left"].ToString();
        right.text = keys["right"].ToString();
        jump.text = keys["jump"].ToString();
        crouch.text = keys["crouch"].ToString();
        use.text = keys["use"].ToString();
        */
        movescript = GetComponent<MoveScript>();
    }

    void Update()
    {
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
            isCrouching = false;
        }

        movescript.Move(Input.GetAxis("Horizontal"), isCrouching, isJumping);
        
        if (Input.GetKeyDown(keys["shoot"]))
        {
            // Shoot
        }
        if (Input.GetKeyDown(keys["use"]))
        {
            // Move right
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
