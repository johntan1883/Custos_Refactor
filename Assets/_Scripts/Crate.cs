using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour, IInteractable
{
    private PlayerInteractablUI playerInteractablUI;
    private AudioClip crateBreakSFX;


    private void Awake()
    {
        playerInteractablUI = GetComponent<PlayerInteractablUI>();
    }

    private void Start()
    {
        crateBreakSFX = GameAssets.Instance.CrateBreakSoundClip;
    }

    void IInteractable.BlindBoyInteract(BlindBoy blindBoy)
    {
        
    }

    public void Interact(Player player)
    {
        Debug.Log("Destroy crate");

        SoundFXManager.Instance.PlaySoundFXClip(crateBreakSFX, transform, 0.3f);

        playerInteractablUI.HideInteractableIcon();

        Destroy(this.gameObject);
    }
}
