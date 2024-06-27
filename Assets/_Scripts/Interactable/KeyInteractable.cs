using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable
{
    private PlayerInteractablUI playerInteractablUI;

    private bool blindBoyIsHoldingKey;

    public bool BlindBoyIsHoldingKey() => blindBoyIsHoldingKey;

    private void Awake()
    {
        playerInteractablUI = GetComponent<PlayerInteractablUI>();        
    }
    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        blindBoy.GrabAndDrop(gameObject);
        blindBoyIsHoldingKey = true;
    }

    public void Interact(Player player)
    {
        player.GrabAndDrop(gameObject);
        playerInteractablUI.HideInteractableIcon();
    }

    public void ShowInteractableIcon()
    {
        playerInteractablUI.ShowInteractableIcon();
    }
}
