using System.Collections;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public Rigidbody body;
    public float forwardForce = 1000.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * forwardForce * Time.deltaTime;
        StartCoroutine(DestroyObject());
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //setup bullet collisions
        collision.gameObject.SetActive(false);
        collision.gameObject.GetComponent<TrailRenderer>().Clear();
        Destroy(this.gameObject);

    }


}
