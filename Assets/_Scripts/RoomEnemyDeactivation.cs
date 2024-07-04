using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyDeactivation : MonoBehaviour
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
            DeactivateEnemy();
        }
    }

    private void DeactivateEnemy()
    {
        foreach (GameObject enemy in enemiesArray)
        {
            if (isEnemyActivated())
            {
                enemy.SetActive(false);
            }
        }
    }

    private bool isEnemyActivated()
    {
        foreach (GameObject enemy in enemiesArray)
        {
            if (enemy.activeSelf) // Use activeSelf to check if the GameObject is active
            {
                return true;
            }
        }

        return false;
    }
}
