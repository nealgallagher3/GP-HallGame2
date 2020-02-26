using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    private float actionTime = 0f;


    public Transform firePoint;
    public GameObject bulletPrefab;

    public float waitPeriod = 2f;
    
    void Update()
    {
        if (Time.time > actionTime)
        {
            actionTime = Time.time + waitPeriod;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
