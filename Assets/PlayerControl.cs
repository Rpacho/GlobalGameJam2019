using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    // Player RigidBody
    public Rigidbody2D theRB;
    public Animator ani;

    [SerializeField] public int moveSpeed = 3;
    [SerializeField] public int jumpSpeed = 5;

    // State
    //bool isItAlive = true;

    public void Awake()
    {
        theRB = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
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
            flip();
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
        bool playerHorizontalSpeed = Mathf.Abs(theRB.velocity.x) > Mathf.Epsilon;
        ani.SetBool("Running", playerHorizontalSpeed);

    }

    public void jump()
    {


        if (Input.GetButtonDown("Jump"))
        { 
            Vector2 jumpVelocity = new Vector2(0, jumpSpeed);
            theRB.velocity += jumpVelocity;
        }

    }

    public void flip()
    {
        bool playerHorizontalSpeed = Mathf.Abs(theRB.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(theRB.velocity.x), 1f);
        }
    }
}
