using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // public attibutes/methods can be accessed by Unity (inspector) and other scripts
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        // gets reference thru unity to Rigidbody component attached to this script's GameObject
        rb = GetComponent<Rigidbody>();
        count = 0;
        jumpCount = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // look up documentation for OnMove
    void OnMove(InputValue movementValue)
    {
        // where is this type defined
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    // does this handle collision with ground playably? yep awesome
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            jumpCount = 0;
        }
    }

    void Update()
    {
        // JUMP HANDLING
        

        // sort of old school style input scheme without using Input Actions Editor
        if (Keyboard.current.spaceKey.wasPressedThisFrame && jumpCount < 2)
        {
            // could add jump multiplier like speed
            Vector3 jump = new Vector3(0.0f, 200.0f, 0.0f);
            rb.AddForce(jump);
            jumpCount++;
        }
    }

    // physics based update vs normal update for unity
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    // Colliders: participate in rigid body collisions
    // Triggers: only notify when another object is overlapping

    // called by Unity when obect first touches another Collider (aka other)
    private void OnTriggerEnter(Collider other)
    {
        // consider deactivation vs destruction. Do you want to add any additional functionality?

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // this deactivates the collided GameObject
            count++;

            SetCountText();
        }
        // however we don't want to deactivate ANY object the Player touches:
        // solution: use Unity Tag system, and if statement as done above
    }
}

/* FURTHER NOTES:

Collider recap: 
So to recap, static colliders shouldn't move like walls and floors. 
Dynamic colliders can move and have a Rigidbody attached. 
Standard Rigidbodies are moved using physics' forces. 
Kinematic Rigidbodies are moved using their transform. 
*/