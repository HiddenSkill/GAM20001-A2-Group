using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField, Range(50, 250)]
    public int offset = 50;


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
         cam.transform.position = player.transform.position - new Vector3(0.0f, 0.0f, offset);
    }
}
