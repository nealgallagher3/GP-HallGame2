using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rig;
    
   
    void Start()
    {
        rig.velocity = transform.forward * speed;
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(gameObject);
    }

    
    void Update()
    {
        
    }
}
