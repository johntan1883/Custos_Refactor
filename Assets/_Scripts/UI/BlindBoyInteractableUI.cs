using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindBoyInteractableUI : MonoBehaviour
{
    [SerializeField] private Transform BlindBoyInteractableIcon;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<BlindBoy>() == true)
        {
            BlindBoyInteractableIcon.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<BlindBoy>() == true)
        {
            BlindBoyInteractableIcon.gameObject.SetActive(false);
        }
    }

    public void HideInteractableIcon()
    {
        BlindBoyInteractableIcon.gameObject.SetActive(false);
    }

    public void ShowInteractableIcon()
    {
        BlindBoyInteractableIcon.gameObject.SetActive(false);
    }
}
