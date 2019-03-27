using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D myRigidBody;
    public float jumpSpeed;
//Don't forget what is Capitalized and what isn't

//all the bits for jumping.
    public Transform groundCheck; 
    public float groundCheckRadius; // how big of a bubble is looking for ground. 
    public LayerMask whatIsGround; // are you ground? layer checker.
    public bool isGrounded; //Yaah! or nah! true or false. 0 or 1 , egg or chicken.
    // ADD A SPELL CHECKER!!!!

    private Animator myAnnie;

    void Start()

    {
        myRigidBody = GetComponent<Rigidbody2D>(); //this grabs the component rigidbody , Which just so happens to be the physics componet :)
        myAnnie = GetComponent<Animator>(); // this grabs the player animator component.

    }

    // Update is called once per frame
    void Update()
    {         
        
        
        
        
        /* if the input for horizontal is true, do a thing. why check for more than zero? 
because Movespeed will = more than zero. in this case ">0 means the same thing as "go right".
but since we are using a rigidbody we want to use velocity 
https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html     */
        if(Input.GetAxisRaw("Horizontal") > 0f)
        {  // pressing right increases move speed by 5 making move speed > 0. 
            myRigidBody.velocity = new Vector3(moveSpeed,myRigidBody.velocity.y,0f);

        
        }
        
        else if(Input.GetAxisRaw("Horizontal") < 0f)
            {
                myRigidBody.velocity = new Vector3(-moveSpeed,myRigidBody.velocity.y,0f);
            }
        else
            {
                myRigidBody.velocity = new Vector3 (0f,myRigidBody.velocity.y,0f);
            }      

        if(Input.GetButtonDown("Jump") && isGrounded) // both jump needs to be pressed. and the player must be on the ground. 
        //the bool isGrounded is a trigger. 
            {
                myRigidBody.velocity=new Vector3(myRigidBody.velocity.x,jumpSpeed,0f);
            }

        myAnnie.SetFloat("Speed",Mathf.Abs (myRigidBody.velocity.x));
        myAnnie.SetBool("Ground",isGrounded);

        // Need to regulate the jump. over lap circle (https://docs.unity3d.com/ScriptReference/Physics2D.OverlapCircle.html)
        //it's pretty much a bubble around the player. when this bubble is in contact with the ground , No jump.
       //                                     point of space = groundcheck, how big is this check area, is it touching the layer ground? 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);

        



    }
}