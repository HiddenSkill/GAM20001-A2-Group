using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    public bool isMoving;
    private bool facingRight = true;
    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        isMoving = rb.velocity.x != 0;  
        /*if(rb.velocity.x < 0 && facingRight == true)
        {
            Flip();
        }
        else if(rb.velocity.x > 0 && facingRight == false)
        {
            Flip();
        }*/

        anim.SetBool("isMoving", isMoving);
        
        

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += new Vector3(0.5f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position -= new Vector3(0.5f, 0.0f, 0.0f);
        }
    }
    /*void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }*/
}
