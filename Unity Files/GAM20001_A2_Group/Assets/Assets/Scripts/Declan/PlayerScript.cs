using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    public bool isMoving;
    private bool facingRight = true;
    private int moveSpeed = 150;
    private float timeSincePlayed;

    public AudioSource footStep;
    // Update is called once per frame

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        timeSincePlayed += Time.deltaTime;
        float xAxis = Input.GetAxisRaw("Horizontal");
        float translation = xAxis * moveSpeed;



        //Check if character is moving
        if (xAxis == 1 || xAxis == -1)
        {
            isMoving = true;
            if (facingRight && xAxis == -1)
            {
                Flip();
            }
            else if (!facingRight && xAxis == 1)
            {
                Flip();
            }
            
        }
        else
        {
            isMoving = false;
        }

        //idk why this work when its false? but it works.... so....
        if(!isMoving)
        {
            footStep.Play();
        }




        anim.SetBool("isMoving", isMoving);

    

        transform.Translate(Mathf.Abs(translation *= Time.deltaTime), 0, 0);
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(translation);
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
