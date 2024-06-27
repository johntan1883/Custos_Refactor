using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBoundsManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private PolygonCollider2D[] roomBoundsArray;

    private CinemachineConfiner2D confiner;

    private void Start()
    {
        confiner = virtualCamera.GetComponent<CinemachineConfiner2D>();
    }

    public void SetCameraBounds(int roomIndex)
    {
        if (roomIndex >= 0 && roomIndex < roomBoundsArray.Length)
        {
            confiner.m_BoundingShape2D = roomBoundsArray[roomIndex];
        }
        else
        {
            Debug.LogWarning("Room bounds index out of range: " + roomIndex);
        }
    }
}
