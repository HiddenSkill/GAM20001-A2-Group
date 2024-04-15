using System.Collections;
using System.Collections.Generic;
using Assets.Assets.Scripts.Harrison;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HarryPlayerScript : MonoBehaviour
{
    #region Constants

    private const float MovementSpeed = 5f;
    private const float JumpPower = 35f;

    #endregion

    #region Fields

    private PlayerState _playerState;
    private Rigidbody2D _rigidbody;
    private AudioSource _source;

    private int _directionOffset;
    #endregion

    #region Methods

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
        _directionOffset = 1;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 horizontalMovement = new Vector3(horizontalInput * MovementSpeed * Time.deltaTime * _directionOffset, 0f, 0f);
        transform.Translate(horizontalMovement);

        // Vertical Movement (Jumping)
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        ApplyGravity();


        if (horizontalInput < 0 && _directionOffset > 0)
        {
            _directionOffset = -1;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontalInput > 0 && _directionOffset < 0)
        {
            _directionOffset = 1;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    }

    void Jump()
    {
        // Add a vertical force to the character for jumping
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, JumpPower);
    }

    void ApplyGravity()
    {
        // Apply gravity to simulate falling
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y > 0)
        {
            // If character is moving upwards, reduce the velocity gradually to give a smooth jump
            rb.velocity += Vector2.up * Physics2D.gravity.y * (JumpPower - 1) * Time.deltaTime;
        }
        else
        {
            // Apply regular gravity
            rb.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Gem"))
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(100);
            }
            Destroy(collision.gameObject);
            return;
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            DeathManager deathManager = FindObjectOfType<DeathManager>();
            if (deathManager != null)
            {
                deathManager.AddDeath();
                _source.Play();
            }
            transform.position = new Vector3(-14.3f, 0.01f, -2f);
            transform.rotation = Quaternion.identity;
        }
    }

    #endregion



}
