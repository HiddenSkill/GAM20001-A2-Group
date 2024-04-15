using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject player;
    private float timeToDie;
    public GameObject gunshotParticle;
    public float bulletDamage = 1;
    enemy objectHit;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Destroy(this.gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            objectHit = collision.gameObject.GetComponent<enemy>();
            objectHit.takeDamage(bulletDamage);
            Instantiate(gunshotParticle, collision.GetContact(0).point, Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(gunshotParticle, 2f);
        }
    
    }
}   
