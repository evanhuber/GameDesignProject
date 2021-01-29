using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    //public TMP_Text endgame;
    //public TMP_Text death;

    float moveForward;
    float moveSide;
    float moveUp;
    //public float health;
    //public float damage;

    public float speed = 5f;
    public float jumpSpeed = 5f;

    Rigidbody rig;

    bool isGrounded;
    //public bool reachedEnd;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Taking input from device
        moveForward = Input.GetAxis("Vertical") * speed;
        moveSide = Input.GetAxis("Horizontal") * speed;
        moveUp = Input.GetAxis("Jump") * jumpSpeed;

        //Moving the character forward and on sides
        rig.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * rig.velocity.y);

        //Make character jump
        if (isGrounded && moveUp != 0)
        {
            rig.AddForce(transform.up * moveUp, ForceMode.VelocityChange);
            isGrounded = false;
        }

        //if (reachedEnd == true)
        //{
        //    endgame.text = "You survived!";
        //}

        //if (health <= 0)
        //{
        //    death.text = "You Died!";
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Finish")
    //    {
    //        reachedEnd = true;
    //    }
    //}

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        health -= damage;
    //        Debug.Log(health);
    //    }
    //}
}
