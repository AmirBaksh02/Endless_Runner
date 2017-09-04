using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMotor : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveVector;

    //delete here 
    private Rigidbody rb;
    public bool onGround;

    private float speed = 5.0f;

   private float verticalVelocity = 0.0f;
   private float gravity = 0.0f;

    private bool isDead = false; 

   
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();

      

    }



    // Update is called once per frame
    void Update()
    {
        

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {

            verticalVelocity = 0.0f;
        }
        else
            {
                verticalVelocity -= gravity * Time.deltaTime; 
            } 


        //X - Left and Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //Y - Up and Down
        //moveVector.y = Input.GetAxisRaw("Vertical") * speed; 
        moveVector.y = verticalVelocity;

        //Z - Forward and Backward 
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);

        //delete here 
     

    }
  

    //controlling speed with private float 
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier; 
    }

    //delete here 
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;

        }

    }

    //It is being called every time our capsule hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy")
            Death(); 
    }

    private void Death()
    {

        isDead = true;
        GetComponent<Score>().OnDeath(); 

    }

}



