using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : MonoBehaviour, IInteractable
{
    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        blindBoy.GrabAndDrop(gameObject);
    }

    public void Interact(Player player)
    {
        player.GrabAndDrop(gameObject);
    }
}
