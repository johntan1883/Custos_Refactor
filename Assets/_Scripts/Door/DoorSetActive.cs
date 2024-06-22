using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }

    public void CloseDoor()
    {
        gameObject.SetActive(true);
    }


    public void ToggleDoor()
    {
        throw new System.NotImplementedException();
    }
}
