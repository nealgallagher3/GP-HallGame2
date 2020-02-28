using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource soundSource;
    public AudioClip arrowSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        
    }


    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        AudioSource.PlayClipAtPoint(arrowSound, transform.position);

    }
}
