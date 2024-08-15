using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    public event Action OnDetectPlayer; //delegate that return void

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();

            if (player != null && !player.isHidden)
            {
                OnDetectPlayer?.Invoke();
            }
        }
    }
}
