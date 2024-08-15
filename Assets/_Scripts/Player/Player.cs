using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Jump")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.5f;
    
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheckPosition;
    [SerializeField] private Vector2 groundCheckBoxSize;

    [Header("Interact")]
    [SerializeField] private Vector2 interactRange;
    [SerializeField] private Transform interactPosition;
    [SerializeField] private LayerMask interactLayerMask;

    [Header("Grab & Drop")]
    [SerializeField] private Transform grabPoint;
    private GameObject grabbedObject;

    [Header("Bark")]
    [SerializeField] private Vector2 soundDetectArea;
    [SerializeField] private LayerMask soundLayerMask;
    [SerializeField] private GameObject lastBarkLocationPrefab;
    [SerializeField] private BlindBoy blindBoy;
    [SerializeField] private BlindBoyInteractable blindBoyInteractable;
    private GameObject lastBarkLocationInstance;
    private AudioClip barkToFollowSoundClip;
    private AudioClip barkToInteractSoundClip;

    private GameInput gameInput;

    public static Player Instance { get; private set; }
    public bool isHidden;

    private float moveInput;
    private float jumpTimeCounter;
    private bool isWalking;
    private bool isFacingRight = true;
    private bool isJumping;
    private bool isGrounded;
    private Rigidbody2D rb;

    public bool IsWalking() => isWalking;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        gameInput = FindAnyObjectByType<GameInput>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        barkToFollowSoundClip = GameAssets.Instance.BarkToFollowSoundClip;
        barkToInteractSoundClip = GameAssets.Instance.BarkToInteractSoundClip;
    }

    void Update()
    {
        if (!PauseMenu.IsPaused)
        {
            HandleMovement();
            Flip();
            CheckGrounded();
            HandleJump();
            Interact();
            BarkToFollow();
            BarkToInteract();
            HandleDrop();
        }
    }

    private void CheckGrounded()
    {
        // Cast a box from the groundCheckPosition downwards to check for ground
        Collider2D hit = Physics2D.OverlapBox(groundCheckPosition.position, groundCheckBoxSize, 0f, groundLayer);

        // If the boxcast hits something, the player is considered grounded
        isGrounded = hit != null;
    }

    private void HandleMovement()
    {
        moveInput = gameInput.GetMovementX();

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        //To check if player is walking
        isWalking = Mathf.Abs(moveInput) > 0.1f;
    }

    private void Flip()
    {
        if (isFacingRight && moveInput < 0f || !isFacingRight && moveInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void HandleJump()
    {
        if (gameInput.GetJumpInputDown() && isGrounded)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (gameInput.GetJumpInput() && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (gameInput.GetJumpInputUp())
        {
            isJumping = false;
        }
    }

    private void HandleDrop()
    {
        if (gameInput.GetDropInput())
        {
            Drop();
        }
    }

    private void Interact()
    {
        if (gameInput.GetInteractInput())
        {
            Collider2D[] colliderArray = Physics2D.OverlapBoxAll(interactPosition.position, interactRange, 0f, interactLayerMask);

            //Find the closest interactable object
            Collider2D closestCollider = null;
            float minDistance = float.MaxValue;

            foreach (Collider2D collider in colliderArray)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < minDistance && collider.TryGetComponent(out IInteractable interactable))
                {
                    minDistance = distance;
                    closestCollider = collider;
                }
            }

            //Interact with the closest object if found
            if (closestCollider != null && closestCollider.TryGetComponent(out IInteractable closestInteractable))
            {
                closestInteractable.Interact(this);
            }
        }
    }


    public void Grab(GameObject interactableObject)
    {
        if (grabbedObject == null)
        {
            grabbedObject = interactableObject;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbedObject.transform.position = grabPoint.position;
            grabbedObject.transform.SetParent(grabPoint);
            Debug.Log(grabbedObject + "is set to child");
        } 
        //else
        //{
        //    if (grabbedObject.TryGetComponent(out KeyInteractable keyInteractable))
        //    {
        //        keyInteractable.ShowInteractableIcon();
        //    }

        //    if (grabbedObject.TryGetComponent(out BlindBoyInteractable blindBoyInteractable))
        //    {
        //        blindBoyInteractable.ShowInteractableIcon();
        //    }

        //    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //    grabbedObject.transform.SetParent(null);
        //    grabbedObject = null;
        //    Debug.Log(interactableObject + "'s parent is set to null");
        //}
    }

    private void Drop()
    {
        if (grabbedObject != null)
        {
            // Drop the currently grabbed object
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            Debug.Log("Dropped the grabbed object.");
        }
        else
        {
            Debug.Log("No object to drop.");
        }
    }

    private void BarkToFollow()
    {
        if (!blindBoyInteractable.IsFollowing())
        {
            if (gameInput.GetBarkToFollowInput())
            {
                SoundFXManager.Instance.PlaySoundFXClip(barkToFollowSoundClip, transform, 0.3f);

                if (lastBarkLocationInstance != null)
                {
                    Destroy(lastBarkLocationInstance);
                }

                lastBarkLocationInstance = Instantiate(lastBarkLocationPrefab, transform.position, Quaternion.identity);

                Collider2D[] colliderArray = Physics2D.OverlapBoxAll(transform.position, soundDetectArea, 0f, soundLayerMask);

                foreach (Collider2D collider in colliderArray)
                {
                    if (collider.TryGetComponent(out BlindBoyInteractable blindBoy))
                    {
                        blindBoy.MoveToSoundLocation(lastBarkLocationInstance.transform);
                    }
                }
            }
        }
    }

    public void OnBlindBoyReachedLocation()
    {
        if (lastBarkLocationInstance != null)
        {
            Destroy(lastBarkLocationInstance);
            lastBarkLocationInstance = null;
        }
    }

    private void BarkToInteract()
    {
        if (gameInput.GetBarkToInteractInput())
        {
            SoundFXManager.Instance.PlaySoundFXClip(barkToInteractSoundClip, transform, 1f);

            blindBoy.StartInteractingWithObject();
        }
    }
    //Visualize the groundCheckRadius
    private void OnDrawGizmos()
    {
        ////Groundcheck box
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(groundCheckPosition.position, new Vector3(groundCheckBoxSize.x, groundCheckBoxSize.y, 0f));

        ////Overlapped interact box
        //Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(interactPosition.position, interactRange);

        //Sound detect area
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, soundDetectArea);
    }
}

