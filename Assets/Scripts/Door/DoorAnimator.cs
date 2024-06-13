using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour, IDoor
{
    private Animator doorAnimator;

    private void Awake()
    {
        doorAnimator = GetComponent<Animator>();
    }

    public void CloseDoor()
    {
        doorAnimator.SetBool("Open", false);
    }

    public void OpenDoor()
    {
        doorAnimator.SetBool("Open", true);
    }

    public void ToggleDoor()
    {
        throw new System.NotImplementedException();
    }
}
