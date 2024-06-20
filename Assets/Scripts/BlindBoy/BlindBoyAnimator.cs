using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindBoyAnimator : MonoBehaviour
{
    private const string IS_FOLLOWING = "IsFollowing";
    private const string IS_MOVING = "IsMoving";
    private const string PICK_UP = "PickUp";

    [SerializeField] private BlindBoyInteractable blindBoy;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_FOLLOWING, blindBoy.IsFollowing());
        animator.SetBool(IS_MOVING, blindBoy.IsMoving());
    }
}
