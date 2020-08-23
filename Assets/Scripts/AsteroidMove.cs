using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{

    public Rigidbody body;
    Renderer m_Renderer;


    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (!m_Renderer.isVisible)
        {
            removeObject();
        }
    }

    public void removeObject()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
