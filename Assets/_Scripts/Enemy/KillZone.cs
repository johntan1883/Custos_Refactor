using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    [SerializeField] private EnemyDetectPlayer enemyDetectPlayer;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        boxCollider2D.enabled = false;

        enemyDetectPlayer.OnDetectPlayer += EnemyDetectPlayer_OnDetectPlayer;

    }

    private void EnemyDetectPlayer_OnDetectPlayer()
    {
        boxCollider2D.enabled=true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Killed Player");
        }
    }
}
