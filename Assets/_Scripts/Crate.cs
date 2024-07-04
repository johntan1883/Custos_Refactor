using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Crate : MonoBehaviour, IInteractable
{
    [SerializeField] private bool spawnKey = false;
    [SerializeField] private GameObject keyPrefab;
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

        SpawnKey();

        Destroy(this.gameObject);
    }

    private void SpawnKey()
    {
        if (spawnKey == true)
        {
            Instantiate(keyPrefab,transform.position, Quaternion.identity);
            Debug.Log("Key spawned");
            spawnKey = false;
        }
    }
}
