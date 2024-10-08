using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class BushesHidingEffect : MonoBehaviour
{   
    [SerializeField] private GameObject screenDarkPanel;
    [SerializeField] private float zoomInSize = 3f;
    [SerializeField] private float zoomOutSize = 8f;

    private bool isHiding = false;
    private Transform player;
    private CameraZoomManager cameraZoomManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>().transform;

        cameraZoomManager = FindObjectOfType<CameraZoomManager>();
    }

    public void ToggleHidingEffect(bool hide)
    {
        isHiding = hide;
        screenDarkPanel.SetActive(isHiding);

        if (isHiding)
        {
            //Make sure the panel starts at the player's current position
            Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(player.position);
            screenDarkPanel.transform.position = playerScreenPosition;

            //Queue zoom in
            cameraZoomManager.RequestZoom(zoomInSize);
        }
        else
        {
            //Queue zoom out
            cameraZoomManager.RequestZoom(zoomOutSize);
        }
    }

    
}
