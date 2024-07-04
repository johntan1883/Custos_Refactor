using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyActivation : MonoBehaviour
{
    [SerializeField] private GameObject[] enemiesArray;

    private void Awake()
    {
        foreach (GameObject enemy in enemiesArray)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            ActivateEnemy();
        }
    }

    private void ActivateEnemy()
    {
        foreach (GameObject enemy in enemiesArray)
        {
            enemy.SetActive(true);
        }
    }
}
