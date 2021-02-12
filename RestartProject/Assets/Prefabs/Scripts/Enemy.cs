using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    //public int Health;
    public Transform player;
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
        Vector3 direction = player.position - transform.position;
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
}
