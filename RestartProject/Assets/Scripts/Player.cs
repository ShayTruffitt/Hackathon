using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int Health;
    public GameObject playerShip;
    public GameObject deathAnimation;

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
        }

    }
}
