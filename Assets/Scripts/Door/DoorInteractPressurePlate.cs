using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorInteractPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    [SerializeField] private GameObject doorVisual;
    
    private IDoor doorGO;
    private IDoor doorV;

    private float timer;

    private bool isPlayerOnPlate = false;
    private bool isBlindBoyOnPlate = false;

    private void Awake()
    {
        doorGO = doorGameObject.GetComponent<IDoor>();
        doorV = doorVisual.GetComponent<IDoor>();
    }

    private void Update()
    {
        if (isPlayerOnPlate || isBlindBoyOnPlate)
        {
            OpenDoors();
            timer = 0.5f; // Reset the timer each frame the character is on the plate
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                CloseDoors();
            }
        }
    }

    private void OpenDoors()
    {
        doorGO.OpenDoor();
        doorV.OpenDoor();
    }

    private void CloseDoors()
    {
        doorGO.CloseDoor();
        doorV.CloseDoor();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            isPlayerOnPlate = true;
        }

        if (collider.GetComponent<BlindBoy>() != null)
        {
            isBlindBoyOnPlate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            isPlayerOnPlate = false;
        }

        if (collider.GetComponent<BlindBoy>() != null)
        {
            isBlindBoyOnPlate = false;
        }
    }


}
