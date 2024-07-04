using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractAutomatic : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject doorVisual;
    private IDoor doorGO;
    private IDoor doorV;

    private bool isBlindBoyInRange = false;
    private bool canOpenDoor = false;
    private GameObject keyGameObject;
    private AudioClip doorOpenSFX;
    private bool doorOpened = false;

    private void Awake()
    {
        doorGO = doorGameObject.GetComponent<IDoor>();
        doorV = doorVisual.GetComponent<IDoor>();

        doorOpenSFX = GameAssets.Instance.DoorOpenSoundClip;
    }

    private void Update()
    {
        if (!doorOpened && isBlindBoyInRange && canOpenDoor)
        {
            OpenDoor();
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<BlindBoy>() != null)
        {
            isBlindBoyInRange = true;
        }

        if (collider.GetComponent<KeyInteractable>() != null)
        {
            keyGameObject = collider.gameObject;
            canOpenDoor = keyGameObject.GetComponent<KeyInteractable>().BlindBoyIsHoldingKey();
        }
    }

    private void OpenDoor()
    {
        doorGO.OpenDoor();
        doorV.OpenDoor();
        SoundFXManager.Instance.PlaySoundFXClip(doorOpenSFX, transform, 1f);
        DestroyKey();
        DisableScript();
        doorOpened = true; // Ensure this only happens once
    }

    private void DestroyKey()
    {
        if (keyGameObject != null)
        {
            Destroy(keyGameObject);
        }
    }

    private void DisableScript()
    {
        this.enabled = false;
    }
}
