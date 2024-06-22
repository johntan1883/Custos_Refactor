using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSetActive : MonoBehaviour, IDoor
{
    public void OpenDoor()
    {
        gameObject.SetActive(true);
    }

    public void CloseDoor()
    {
        gameObject.SetActive(false);
    }

    public void ToggleDoor()
    {
        throw new System.NotImplementedException();
    }

    
}
