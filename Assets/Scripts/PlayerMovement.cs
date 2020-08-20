using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 200f;
    public float sidewaysForce = 50f;
    public float acceleration = 4f;
    private Quaternion target, pitch;

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

        target = Quaternion.Euler(0, 0, -Input.GetAxisRaw("Horizontal") * 40);
        pitch = Quaternion.Euler(-Input.GetAxisRaw("Hover") * 20, 0, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, target, acceleration * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, pitch, acceleration * Time.deltaTime);


        transform.position += transform.forward * activeForwardsSpeed * Time.deltaTime;
        transform.position += (Vector3.right * activeStrafeSpeed * Time.deltaTime);
        transform.position += (transform.up * activeHoverSpeed * Time.deltaTime);
    }
}
