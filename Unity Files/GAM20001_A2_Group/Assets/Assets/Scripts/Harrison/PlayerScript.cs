using System.Collections;
using System.Collections.Generic;
using Assets.Assets.Scripts.Harrison;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HarryPlayerScript : MonoBehaviour
{
    #region Constants

    private const float MovementSpeed = 5f;
    private const float JumpPower = 5f;

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

        Vector3 movement = new Vector3(horizontalInput * _directionOffset * MovementSpeed, verticalInput * JumpPower, 0f) * MovementSpeed * Time.deltaTime;
        transform.Translate(movement);
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
