using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public Rigidbody body;
    public float forwardForce = 1000.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * forwardForce * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //setup bullet collisions
        collision.gameObject.SetActive(false);
        Destroy(this.gameObject);

    }


}
