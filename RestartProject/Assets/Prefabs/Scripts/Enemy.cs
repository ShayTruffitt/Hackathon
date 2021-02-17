using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    //public int Health;
    public Transform playerToFollow;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    Vector2 movement;
     
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

    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    public void TakeDamage()
    {
        Destroy(gameObject);
        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.enemiesInRoom--;

        if(enemySpawner.spawnTime <=0 &&enemySpawner.enemiesInRoom <= 0)
        {
            enemySpawner.spawnerDone = true;
        }



    }

    public GameObject Ship;
    public GameObject damageAnimation;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit Detected");
        //Destroy(Ship);
        GameObject e = Instantiate(damageAnimation) as GameObject;
    }

    void OnCollisionEnter(Collision c)
    {

        // If the object we hit is the enemy
        if (c.gameObject.tag == "Enemy")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 dir = c.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * moveSpeed);
        }
    }




}
