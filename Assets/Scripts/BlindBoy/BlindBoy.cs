using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindBoy : MonoBehaviour
{
    [Header("BlindBoy Interact")]
    [SerializeField] private Vector2 interactRange;
    [SerializeField] private Transform interactPosition;
    [SerializeField] private LayerMask interactLayerMask;

    [Header("Grab & Drop")]
    [SerializeField] private Transform grabPoint;
    private GameObject grabbedObject;

    [Header("Run Away Settings")]
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float runDuration = 2f;

    private Vector2 runDirection;
    private bool isRunningAway = false;

    public void StartInteractingWithObject()
    {
        Collider2D closestCollider = FindClosestInteractable();

        //Interact with the closest object if found
        if (closestCollider != null && closestCollider.TryGetComponent(out IInteractable closestInteractable))
        {
            closestInteractable.BlindBoyInteract(this);
        }
    }

    private Collider2D FindClosestInteractable()
    {
        Collider2D[] colliderArray = Physics2D.OverlapBoxAll(interactPosition.position, interactRange, 0f, interactLayerMask);

        Collider2D closestCollider = null;
        float minDistance = float.MaxValue;

        foreach (Collider2D collider in colliderArray)
        {
            float distance = Vector2.Distance(transform.position, collider.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestCollider = collider;
            }
        }

        return closestCollider;
    }

    public void GrabAndDrop(GameObject interactableObject)
    {
        if (grabbedObject == null)
        {
            grabbedObject = interactableObject;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(grabPoint);
            Debug.Log(grabbedObject + "is set to child");
        }
        else
        {
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            Debug.Log(interactableObject + "'s parent is set to null");
        }
    }

    private void OnDrawGizmos()
    {
        //Overlapped interact box
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(interactPosition.position, interactRange);
    }

    public void ReactToBellSFX(Vector2 soundSourcePosition)
    {
        if (!isRunningAway)
        {
            Vector2 directionToSound = (soundSourcePosition - (Vector2)transform.position).normalized;
            runDirection = -directionToSound;
            StartCoroutine(RunAway());
        }
        
    }

    private IEnumerator RunAway()
    {
        isRunningAway = true;
        float timer = 0f;

        while (timer < runDuration)
        {
            transform.Translate(runDirection * runSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        isRunningAway = false;
        Debug.Log("Boy Stopped RUNNING");
    }
}
