using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Boolean smoothed;

    private Vector3 smoothedPos;
    private Vector3 finalPos;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    //Fixed update causes irregular camera behaviour when scene is switched 
    void FixedUpdate()
    {
        Vector3 desiredPos = player.position + offset;
        if (smoothed)
        {

            smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
            finalPos = new Vector3(smoothedPos.x, smoothedPos.y, desiredPos.z);
        }
        else
        {
            finalPos = desiredPos;
        }

        transform.position = finalPos;
    }
}
