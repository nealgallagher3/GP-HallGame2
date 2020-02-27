using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 5.0f;
    
    

    
    void Update()
    {
        transform.Rotate(0.0f, 1.0f * speed, 0.0f);
    }
}
