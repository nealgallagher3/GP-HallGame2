using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource fxxSounds;
    public AudioClip arrowSound;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
            AudioSource.PlayClipAtPoint(arrowSound, transform.position);
        }
        
    }


    void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
