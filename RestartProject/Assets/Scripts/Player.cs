using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Health;
    public GameObject playerShip;
    public GameObject deathAnimation;
    public GameObject HealthFull;
    public GameObject Health80;
    public GameObject Health60;
    public GameObject Health40;
    public GameObject Health20;
    

    private void Start()
    {
        GameManager.instance.playerAlive = true;
    }

    public void TakeDamage(int damage)
    {

        Health -= damage;
        if (Health <= 0)
        {
            Destroy(playerShip);
            Debug.Log("Player has been Hit");
            //Destroy(Ship);
            GameObject e = Instantiate(deathAnimation) as GameObject;
            e.transform.position = transform.position;
            GameManager.instance.playerAlive = false;
            SceneManager.LoadScene(sceneBuildIndex:2);
        }else if(Health <= 200)
        {
            Destroy(Health40);
        }
        else if (Health <= 600)
        {
            Destroy(Health60);
        }
        else if (Health <= 800)
        {
            Destroy(Health80);
        }
        else if (Health <= 1000)
        {
            Destroy(HealthFull);
        }


    }
}
