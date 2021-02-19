using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float reloadTime =5;
    private float nextFireTime = 0;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {

                Shoot();
                nextFireTime = Time.time + reloadTime;

        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }


}

