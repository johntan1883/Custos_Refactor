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
    private bool isKeyInRange = false;
    private GameObject keyGameObject;

    private void Awake()
    {
        doorGO = doorGameObject.GetComponent<IDoor>();
        doorV = doorVisual.GetComponent<IDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<BlindBoy>() != null)
        {
            isBlindBoyInRange = true;
        }

        if (collider.GetComponent<KeyInteractable>() != null)
        {
            isKeyInRange = true;
            keyGameObject = collider.gameObject;
        }

        CheckAndOpenDoor();
    }

    private void CheckAndOpenDoor()
    {
        if(isBlindBoyInRange && isKeyInRange)
        {
            doorGO.OpenDoor();
            doorV.OpenDoor();
            DestroyKey();
        }
    }

    private void DestroyKey()
    {
        if (keyGameObject != null)
        {
            Destroy(keyGameObject);
        }
    }

}
