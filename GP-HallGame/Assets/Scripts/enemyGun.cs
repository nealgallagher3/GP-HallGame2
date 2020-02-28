using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyGun : MonoBehaviour
{
    private float actionTime = 0f;


    public Transform firePoint;
    public GameObject bulletPrefab;

    IEnumerator Freeze()
    {
        waitPeriod = 3f;
        yield return new WaitForSeconds(3f);
        waitPeriod = 1.5f;
    }

    public float waitPeriod = 1.5f;
    
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(Freeze());
        }
    }
}
