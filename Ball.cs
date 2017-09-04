# Endless_Runner

using UnityEngine;
using System.Collections;
using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    //public float speed;
    private float speed = 2000.0f; 
    private bool jumping = false;
    private bool candoublejump = false;
    public float StartDoubleJumpTime;
    public float EndDoubleJumpTime;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if ((!jumping || candoublejump) && Input.GetButtonDown("Jump"))
        {
            jumping = true;
            candoublejump = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
            Invoke("StartDoubleJump", StartDoubleJumpTime);
        }

        Vector3 movement = Camera.main.transform.rotation * new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    void StartDoubleJump()
    {
        candoublejump = true;
        Invoke("EndDoubleJump", EndDoubleJumpTime);
    }

    void EndDoubleJump()
    {
        candoublejump = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            jumping = false;
        }
    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

}
