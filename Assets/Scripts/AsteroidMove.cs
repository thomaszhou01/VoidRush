using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    public Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body.AddForce(Random.Range(-10000.0f, 10000.0f), Random.Range(-10000.0f, 10000.0f), -10000);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
