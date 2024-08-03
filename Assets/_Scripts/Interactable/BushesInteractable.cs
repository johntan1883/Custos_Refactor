using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform teleportDestination;
    [SerializeField] private GameObject [] boundariesArray;

    private bool hasInteracted;
    
    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        
    }

    public void Interact(Player player)
    {
        SpriteRenderer playerSprite = player.GetComponentInChildren<SpriteRenderer>();

        if (playerSprite != null)
        {
            hasInteracted = !hasInteracted; // Toggle the interaction state

            if (hasInteracted == true)
            {
                TeleportPlayer(player);
                EnableBoundaries();
                playerSprite.sortingOrder = -2; //Player is hiding behind the bushes
                player.isHidden = true;
                Debug.Log("Player is hiding in the bushes: " + hasInteracted);
            }
            else
            {
                DisableBoundaries();
                playerSprite.sortingOrder = 0; //Player came out from the bushes
                player.isHidden = false;
            }

        }
    }

    private void TeleportPlayer(Player player)
    {
        if (player != null && teleportDestination != null) 
        { 
            player.transform.position = teleportDestination.position; //Teleport player into the bushes
        }
    }

    private void EnableBoundaries()
    {
        foreach (var boundary in boundariesArray)
        {
            boundary.SetActive(true);
        }
    }

    private void DisableBoundaries()
    {
        foreach (var boundary in boundariesArray)
        {
            boundary.SetActive(false);
        }
    }
}
