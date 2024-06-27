using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractablUI : MonoBehaviour
{
    [SerializeField] private Transform InteractableIcon;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            InteractableIcon.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            InteractableIcon.gameObject.SetActive(false);
        }
    }

    public void HideInteractableIcon()
    {
        InteractableIcon.gameObject.SetActive(false);
    }

    public void ShowInteractableIcon()
    {
        InteractableIcon.gameObject.SetActive(false);
    }

}
