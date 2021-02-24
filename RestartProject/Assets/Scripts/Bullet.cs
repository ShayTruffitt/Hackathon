using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    public GameObject ThisBullet;
    public int damage = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            //take damage requires an Int to be placed
            enemy.TakeDamage(damage);
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