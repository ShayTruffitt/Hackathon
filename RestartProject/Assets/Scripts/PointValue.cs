using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointValue : MonoBehaviour
{
    [SerializeField] float pointValue = 100f;

    public void AddPoints()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.AddToScore(pointValue);
        }
    }
}
