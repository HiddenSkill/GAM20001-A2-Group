using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;
    private Rigidbody2D bulletRB;
    public bool isMoving;
    private bool facingRight = true;
    private int moveSpeed = 5;
    private float timeSincePlayed;
    GameObject floor;
    private float jump = 175f;

    public AudioSource footStep;
    public AudioSource jumpSound;

    public bool isOnGround;
    public bool playerAttack;
    public BoxCollider2D playerCollider;
    public LayerMask layerMask;
    public Transform spawnPoint;

    private RaycastHit2D hit;

    public GameObject bullet;
    private float bulletSpeed = 15.0f;
    private float fireRate = 2f;
    private float timeSinceFired = 0f;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        GameObject floor = GameObject.FindGameObjectWithTag("Floor");
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();
        
    }
    void FixedUpdate()
    {
        timeSincePlayed += Time.deltaTime;
        float xAxis = Input.GetAxisRaw("Horizontal");
        float translation = xAxis * moveSpeed;
        spawnPoint = spawnPoint.transform;



        

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


        isOnGround = isGrounded();
        //Debug.Log(Input.GetAxis("Jump"));


        if (isOnGround && Input.GetAxis("Jump") == 1)
        {
            rb.AddForce(Vector2.up * jump * Time.deltaTime , ForceMode2D.Impulse);
            jumpSound.Play();
        }

        //idk why this work when its false? but it works.... so....
        if(!isMoving)
        {
            footStep.Play();
        }

        if (isOnGround && Input.GetAxis("Fire2") == 1)
        {
            
            attack();
        }
        else
        {
            playerAttack = false;
        }





        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isOnGround", isOnGround);
        anim.SetBool("attack", playerAttack);

    

        transform.Translate(Mathf.Abs(translation *= Time.deltaTime), 0, 0);
        //Debug.Log(Input.GetAxisRaw("Horizontal"));
        //Debug.Log(translation);
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    bool isGrounded()
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -Vector2.up, Color.red);
        //Debug.DrawLine(new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.center.y, playerCollider.bounds.extents.z), new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.center.y + 0.1f, playerCollider.bounds.extents.z), Color.red);
        hit = Physics2D.Raycast(transform.position, -Vector2.up, playerCollider.bounds.extents.y + 0.03f);
        
        if (hit.collider != null)
        {
            
            //Debug.Log("RayCast Hit: " + hit.transform.name);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    void attack()
    {
        if (Time.time >= timeSinceFired)
        {
            playerAttack = true;
            GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D bulletRB = spawnedBullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = spawnPoint.right * bulletSpeed;

            timeSinceFired = Time.time + 1f / fireRate;
            Debug.Log("Bullet Velocity is: " + bulletRB.velocity);

            if (bulletRB == null)
            {
                Debug.Log("No rigidbody found on bullet");
                
            }
        }

    }

}
