using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField, Range(1, 5)]
    public int offset = 3;


    Camera cam;
    GameObject player;
    BoxCollider2D playerCollider;




    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<BoxCollider2D>();
        cam = Camera.main;
    }
    
    

    

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(playerCollider.transform.position.x, playerCollider.transform.position.y, -offset);
    }
}
