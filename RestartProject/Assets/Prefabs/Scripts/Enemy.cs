using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    public int health = 100;
    public Transform playerToFollow;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;
    public GameObject Ship;

    // Start is called before the first frame update
    void Start()
    {
        //allows us to manipulate the object 
        rb = this.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerToFollow.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg -90f;
        direction.Normalize();
        movement = direction;
        RotateTowards(playerToFollow.position);
    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    /*public void TakeDamage()
    {
        Destroy(gameObject);
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.enemiesInRoom--;

        if(enemySpawner.spawnTime <=0 &&enemySpawner.enemiesInRoom <= 0)
        {
            enemySpawner.spawnerDone = true;
        }
    }
    */

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

         Destroy(Ship);
        }
    }
    
    

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit Detected");

        if (health <= 0)
        {
            Destroy(Ship);
       }
        
    }
    */
    /*
    void OnCollisionEnter(Collision c)
    {

        // If the object we hit is the enemy
        if (c.gameObject.tag == "PlayerBullet")
        {

            Debug.Log("hit Detected");
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * moveSpeed);
        }
    }
    */
    private void RotateTowards(Vector2 target)
    {
        var offset = 180f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
