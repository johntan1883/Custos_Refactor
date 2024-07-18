using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparateRoomCameraTrigger : MonoBehaviour
{
    public enum TriggerType { Enter, Exit }
    public TriggerType triggerType;
    public int targetRoomIndex;
    private CameraBoundsManager cameraBoundsManager;

    void Start()
    {
        cameraBoundsManager = FindObjectOfType<CameraBoundsManager>();

        if (cameraBoundsManager == null)
        {
            Debug.LogError("CameraBoundsManager not found in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cameraBoundsManager != null)
            {
                if (triggerType == TriggerType.Enter)
                {
                    cameraBoundsManager.SetSeparateRoomCameraBounds(targetRoomIndex);
                }
                else if (triggerType == TriggerType.Exit)
                {
                    // Assuming the current room is the same as targetRoomIndex
                    cameraBoundsManager.SetSeparateRoomCameraBounds(targetRoomIndex);
                }
            }
            else
            {
                Debug.LogError("CameraBoundsManager reference is null.");
            }
        }
    }
}
