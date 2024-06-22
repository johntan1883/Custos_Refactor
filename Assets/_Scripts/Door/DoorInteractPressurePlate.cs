using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DoorInteractPressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject[] doorGameObjects;
    [SerializeField] private GameObject[] doorVisuals;

    private IDoor[] doorGOs;
    private IDoor[] doorVs;

    private float timer;

    private bool isPlayerOnPlate = false;
    private bool isBlindBoyOnPlate = false;

    private void Awake()
    {
        doorGOs = new IDoor[doorGameObjects.Length];
        doorVs = new IDoor[doorVisuals.Length];

        for (int i = 0; i < doorGameObjects.Length; i++)
        {
            doorGOs[i] = doorGameObjects[i].GetComponent<IDoor>();
        }

        for (int i = 0; i < doorVisuals.Length; i++)
        {
            doorVs[i] = doorVisuals[i].GetComponent<IDoor>();
        }
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
        foreach (var door in doorGOs)
        {
            door.OpenDoor();
        }

        foreach (var door in doorVs)
        {
            door.OpenDoor();
        }
    }

    private void CloseDoors()
    {
        foreach (var door in doorGOs)
        {
            door.CloseDoor();
        }

        foreach (var door in doorVs)
        {
            door.CloseDoor();
        }
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

    public bool CheckIsOnPlate()
    {
        if (isPlayerOnPlate || isBlindBoyOnPlate)
        {
            return true;
        }

        return false;
    }

}
