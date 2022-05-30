using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    public float camSpeed;
    Vector3 distanceToPlayer;


    void Start()
    {
        distanceToPlayer = transform.position - player.transform.position;
    }



    void Update()
    {
        transform.position = player.transform.position + distanceToPlayer;
    }
}
