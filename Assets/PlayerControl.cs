using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    // Player RigidBody
    public Rigidbody2D theRB;
    [SerializeField] public float moveSpeed = 3;
    [SerializeField] public float jumpSpeed = 5;

    // State
    bool isItJumping = false;

    public void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (theRB != null)
        {
            run();
            jump();
        }
        else
        {
            Debug.Log("Player not attach" + gameObject);
        }
        Debug.Log(theRB.velocity);
    }

    public void run()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector2 playerVelocity = new Vector2(inputX*moveSpeed, theRB.velocity.y);
        theRB.velocity = playerVelocity;

    }

    public void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            if (isItJumping == false)
            {
                theRB.velocity += jumpVelocity;
            }
        }

    }
}
