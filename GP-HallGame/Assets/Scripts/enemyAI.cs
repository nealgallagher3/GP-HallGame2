using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    GameObject player;
    NavMeshAgent enemy;
    public AudioSource damageSound;
    public AudioClip freezerSound;

    IEnumerator Freeze()
    {
        enemy.speed = 0;
        yield return new WaitForSeconds(3f);
        enemy.speed = 5;
    }
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        enemy.destination = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            StartCoroutine(Freeze());
            AudioSource.PlayClipAtPoint(freezerSound, transform.position);
        }
    }
}
