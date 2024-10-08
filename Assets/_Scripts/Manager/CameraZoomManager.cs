using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float zoomSpeed = 2f;

    private Queue<float> zoomQueue = new Queue<float>(); // Queue for request zooming
    private bool isZooming = false;

    public bool IsZooming
    {
        get { return isZooming; }
    }

    private void Update()
    {
        if (!isZooming && zoomQueue.Count > 0)
        {
            float targetZoom = zoomQueue.Dequeue();
            StartCoroutine(ZoomCamera(targetZoom));
        }
    }

    public void RequestZoom(float targetSize)
    {
        zoomQueue.Enqueue(targetSize);
    }

    private IEnumerator ZoomCamera(float targetSize)
    {
        isZooming = true;
        float currentSize = virtualCamera.m_Lens.OrthographicSize;

        while (Mathf.Abs(currentSize - targetSize) > 0.01f)
        {
            currentSize = Mathf.Lerp(currentSize, targetSize, zoomSpeed * Time.deltaTime);
            virtualCamera.m_Lens.OrthographicSize = currentSize;
            yield return null;
        }

        virtualCamera.m_Lens.OrthographicSize = targetSize;
        isZooming = false; // Mark zoom as complete
    }
}
