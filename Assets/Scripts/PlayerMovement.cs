using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float boostForce = 20000f;
    public float sidewaysForce = 50f;
    public float upwardsForce = 50f;
    public float acceleration = 4f;
    public float boostTime = 1.0f;
    private Quaternion target, pitch;

    private float activeForwardsSpeed, activeStrafeSpeed, activeHoverSpeed, activeBoostForce;
    private Boolean isBoosting;
    private float boostDirection;

    // Start is called before the first frame update
    void Start()
    {
        isBoosting = false;
    }

    void stopBoost()
    {
        isBoosting = false;
        boostDirection = 0;
    }


    private void Update()
    {
        if (Input.GetButtonDown("Boost") && !isBoosting)
        {
            isBoosting = true;
            Invoke("stopBoost", boostTime);
            boostDirection = Input.GetAxisRaw("Horizontal");
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * sidewaysForce, acceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Vertical") * upwardsForce, acceleration * Time.deltaTime);

        //activate boost
        if (isBoosting)
        {
            activeBoostForce = Mathf.Lerp(activeBoostForce, boostDirection * boostForce, acceleration * 2 * Time.deltaTime);
        }
        else
        {
            activeBoostForce = Mathf.Lerp(activeBoostForce, 0, acceleration * 2 * Time.deltaTime);
        }


        target = Quaternion.Euler(0, 0, -Input.GetAxisRaw("Horizontal") * 90);
        pitch = Quaternion.Euler(-Input.GetAxisRaw("Vertical") * 90, 0, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, acceleration * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pitch, acceleration * Time.deltaTime);


        transform.position += (Vector3.right * activeStrafeSpeed * Time.deltaTime);
        transform.position += (Vector3.right * activeBoostForce * Time.deltaTime);
        transform.position += (Vector3.up * activeHoverSpeed * Time.deltaTime);
    }

    public float zPosition()
    {
        return transform.position.z;
    }
}
