using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sidewaysForce = 50f;
    public float acceleration = 4f;


    private float activeForwardsSpeed, activeStrafeSpeed, activeHoverSpeed;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        activeForwardsSpeed = Mathf.Lerp(activeForwardsSpeed, Input.GetAxisRaw("Vertical") * forwardForce, acceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * sidewaysForce, acceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * sidewaysForce, acceleration * Time.deltaTime);

        transform.position += transform.forward * activeForwardsSpeed * Time.deltaTime;
        transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime); 
    }
}
