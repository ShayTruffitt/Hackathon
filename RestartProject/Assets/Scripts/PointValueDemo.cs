using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointValueDemo : MonoBehaviour
{
    [SerializeField] float pointValue = 100f;

    public void AddPoints()
    {
        //This functionality is added later
        if (GameManager.instance != null)
        {
            GameManager.instance.AddToScore(pointValue);
        }
    }
}