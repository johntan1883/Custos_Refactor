using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInTheBushes : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player.PlayerIsInTheBushes();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        player.PlayerIsNotInTheBushes();
    }

    
}
