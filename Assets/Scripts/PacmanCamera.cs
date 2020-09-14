using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PacmanCamera : MonoBehaviour
{
    //private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 15.1f;
        transform.position = new Vector3(14.5f, -13.6f, -20f);
        /* // main camera follows pacman or "player" tag 
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = 10.0f;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        */
    }

    void LateUpdate()
    {
        /*
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;
        transform.position = temp;
        */
    }
}