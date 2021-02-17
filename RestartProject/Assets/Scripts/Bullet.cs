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
        }

        /*
        if(other.tag== "Enemy")
        {
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = transform.position;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        */
    }
}