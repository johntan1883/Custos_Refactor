using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateAnimator : MonoBehaviour
{
    private const string IS_ON_PLATE = "IsOnPlate";

    [SerializeField] private DoorInteractPressurePlate DoorInteractPressurePlate;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_ON_PLATE, DoorInteractPressurePlate.CheckIsOnPlate());
    }
}
