using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject spawner;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(spawner, Spawnpoint.position, Spawnpoint.rotation);
            Destroy(this);
        }
    }

     
    
}

