using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindBoyInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform followPlayerPosition;
    [SerializeField] private float movingSpeed;
    [SerializeField] private float stoppingDistance;

    private bool isFollowing;
    private bool isFacingRight = true;
    private bool isMoving;
    private bool isMovingToSound;
    private Transform soundLocation;

    public bool IsFollowing() => isFollowing;
    public bool IsMoving() => isMoving;

    public void MoveToSoundLocation(Transform location)
    {
        soundLocation = location;
        isMovingToSound = true;
        isMoving = true;
    }

    private void Update()
    {
        if (isFollowing)
        {
            HandleMovement(followPlayerPosition);
        }
        else if (isMovingToSound)
        {
            HandleMovement(soundLocation);
            if (IsAtLocation(soundLocation))
            {
                StopMoving();
                Player.Instance.OnBlindBoyReachedLocation();
            }
        }

        HandleFlip();
    }

    public void Interact(Player player)
    {
        isFollowing = !isFollowing;
        isMoving = isFollowing;
    }

    private void HandleMovement(Transform target)
    {
        if (IsAtLocation(target))
        {
            StopMoving();
        }
        else
        {
            MoveTowards(target);
        }
    }

    private void MoveTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0f; // Ignore vertical movement
        transform.Translate(direction * movingSpeed * Time.deltaTime);
        isMoving = true;
    }

    private void HandleFlip()
    {
        if ((isMovingToSound && NeedsFlip(soundLocation)) || (isFollowing && NeedsFlip(followPlayerPosition)))
        {
            Flip();
        }
    }

    private bool NeedsFlip(Transform target)
    {
        return (transform.position.x > target.position.x && isFacingRight) || (transform.position.x < target.position.x && !isFacingRight);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 newScale = transform.localScale;
        newScale.x *= -1f;
        transform.localScale = newScale;
    }

    private bool IsAtLocation(Transform target)
    {
        return Vector3.Distance(transform.position, target.position) < stoppingDistance;
    }

    private void StopMoving()
    {
        isMoving = false;
        isMovingToSound = false;
    }

    public void BlindBoyInteract(BlindBoy blindBoy)
    {
        
    }
}
