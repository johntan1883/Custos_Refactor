using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform playerTeleportDestination;
    [SerializeField] private Transform blindBoyTeleportDestination;
    [SerializeField] private float teleportDelay = 0.5f;
    [SerializeField] private CanvasGroup fadeCanvasGroup;

    private BlindBoyInteractableUI blindBoyInteractableUI;
    private Player player;
    private BlindBoy blindBoy;
    

    private void Awake()
    {
        blindBoyInteractableUI = GetComponent<BlindBoyInteractableUI>();
        player = FindObjectOfType<Player>();
        blindBoy = FindObjectOfType<BlindBoy>();
        
    }

    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        blindBoyInteractableUI.HideInteractableIcon();

        StartCoroutine(TeleportWithDelay());
    }

    public void Interact(Player player)
    {
        
    }

    private IEnumerator TeleportWithDelay()
    {
        //Start fade out
        yield return StartCoroutine(FadeScreen(1f));

        //Perform teleportaion
        player.transform.position = playerTeleportDestination.position;
        blindBoy.transform.position = blindBoyTeleportDestination.position;

        //Wait for specific delay
        yield return new WaitForSeconds(teleportDelay);

        //Start fade in
        yield return StartCoroutine(FadeScreen(0f));
    }

    private IEnumerator FadeScreen(float targetAlpha) //target Alpha is the index no for the canvas group
    {
        if (fadeCanvasGroup == null) yield break;

        float fadeSpeed = 1f / teleportDelay;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
