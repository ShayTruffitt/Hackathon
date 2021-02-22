using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemySpawner enemySpawner;

    public int Health;
    public Transform playerToFollow;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float stoppingDistance;
    public float retreatDistance;
    Vector2 movement;
    public GameObject enemyShip;
    public GameObject damageAnimation;
    public int points;




    // Start is called before the first frame update
    void Start()
    {
        //allows us to manipulate the object 
        rb = this.GetComponent<Rigidbody2D>();


        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = playerToFollow.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        direction.Normalize();
        movement = direction;

        if (Vector3.Distance(transform.position, playerToFollow.position) > 1f)
        {
            //MoveTowards(playerToFollow.position);
            RotateTowards(playerToFollow.position);
        }
        if (Vector2.Distance(transform.position, playerToFollow.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, moveSpeed * Time.deltaTime);


        }
        else if (Vector2.Distance(transform.position, playerToFollow.position) < stoppingDistance && Vector2.Distance(transform.position, playerToFollow.position) > retreatDistance)
        {
            transform.position = this.transform.position;

        }
        else if (Vector2.Distance(transform.position, playerToFollow.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerToFollow.position, -moveSpeed * Time.deltaTime);
        }


        enemySpawner = FindObjectOfType<EnemySpawner>();
        enemySpawner.enemiesInRoom--;

    }

    private void FixedUpdate()
    {
        moveEnemy(movement);
    }

    void moveEnemy(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }


    public void TakeDamage(int damage)
    {

        if (enemySpawner.spawnTime <= 0 && enemySpawner.enemiesInRoom <= 0)
        {
            enemySpawner.spawnerDone = true;
        }

        Health -= damage;
        if (Health <= 0)
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.AddToScore(points);
            }


            Destroy(enemyShip);
            GameObject e = Instantiate(damageAnimation) as GameObject;
            e.transform.position = transform.position;
            Destroy(this.gameObject);

        }

    }





    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }

}


