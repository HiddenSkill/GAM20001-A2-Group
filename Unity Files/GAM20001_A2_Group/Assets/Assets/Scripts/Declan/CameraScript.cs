using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField, Range(1, 5)]
    public int offset = 3;


    Camera cam;
    GameObject player;
    


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = Camera.main;
    }
    
    

    

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(player.transform.position.x, cam.transform.position.y, -offset);
    }
}
