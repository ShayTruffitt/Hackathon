using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject explosion;
    public GameObject ThisBullet;
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            //take damage requires an Int to be placed
            player.TakeDamage(damage);
            Destroy(ThisBullet);
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
        }

        
        if(other.CompareTag("Environment"))
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);
        }
       
    }
}