using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform playerTeleportDestination;
    [SerializeField] private float teleportDelay = 0.5f;
    [SerializeField] private CanvasGroup fadeCanvasGroup;

    private PlayerInteractablUI playerInteractableUI;
    private Player player;

    private void Awake()
    {
        playerInteractableUI = GetComponent<PlayerInteractablUI>();
        player = FindObjectOfType<Player>();
    }

    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        
    }

    public void Interact(Player player)
    {
        playerInteractableUI.HideInteractableIcon();

        StartCoroutine(TeleportWithDelay());
    }

    private IEnumerator TeleportWithDelay()
    {
        //Start fade out
        yield return StartCoroutine(FadeScreen(1f));

        //Perform teleportaion
        player.transform.position = playerTeleportDestination.position;

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
