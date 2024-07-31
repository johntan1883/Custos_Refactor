using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    public event Action OnDetectPlayer; //delegate that return void

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnDetectPlayer?.Invoke();
        }
    }
}
