using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform playerTeleportDestination;
    [SerializeField] private Transform blindBoyTeleportDestination;

    private BlindBoyInteractableUI blindBoyInteractableUI;
    private Player player;
    private BlindBoy blindBoy;

    private void Awake()
    {
        blindBoyInteractableUI = GetComponent<BlindBoyInteractableUI>();
        player = FindObjectOfType<Player>();
        blindBoy = FindObjectOfType<BlindBoy>();
    }

    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        blindBoyInteractableUI.HideInteractableIcon();

        TeleportToRoom();
    }

    public void Interact(Player player)
    {
        
    }

    private void TeleportToRoom()
    {
        //Perform teleportaion
        player.transform.position = playerTeleportDestination.position;
        blindBoy.transform.position = blindBoyTeleportDestination.position;
    }
}
