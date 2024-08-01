using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushesInteractable : MonoBehaviour, IInteractable
{
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
                playerSprite.sortingOrder = -2; //Player is hiding behind the bushes
                Debug.Log("Player is hiding in the bushes: " + hasInteracted);
            }
            else
            {
                playerSprite.sortingOrder = 0; //Player came out from the bushes
            }

        }
    }
}
