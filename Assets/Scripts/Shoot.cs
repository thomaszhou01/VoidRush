using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectile;
    public Transform gunpoint1;
    public Transform gunpoint2;
    public Transform ship;

    private Boolean shooting = false;

    private void Start()
    {
        InvokeRepeating("shootBullet", 0.0f, 0.2f);
    }

    public void shootBullet()
    {
        if (shooting)
        {
            GameObject projectile_instance = Instantiate(projectile, gunpoint1.position, Quaternion.identity);
            projectile_instance.transform.rotation = ship.rotation;
            GameObject projectile_instance2 = Instantiate(projectile, gunpoint2.position, Quaternion.identity);
            projectile_instance2.transform.rotation = ship.rotation;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;

        }

        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
        }
    }
}
