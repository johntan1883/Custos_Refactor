using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        //Initial the PlayerInputActions Class and enable the input system
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.PauseMenu.Enable();
    }

    //Returning the x value of move input of player
    public float GetMovementX()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        return inputVector.x;
    }

    //Check if the jump button is pressed
    public bool GetJumpInput()
    {
        return playerInputActions.Player.Jump.IsPressed();
    }

    //Check if the jump button was just pressed
    public bool GetJumpInputDown()
    {
        return playerInputActions.Player.Jump.WasPressedThisFrame();
    }

    //Check if the jump button was just released
    public bool GetJumpInputUp()
    {
        return playerInputActions.Player.Jump.WasReleasedThisFrame();
    }

    public bool GetInteractInput()
    {
        return playerInputActions.Player.Interact.WasPressedThisFrame();
    }

    public bool GetBarkToFollowInput()
    {
        return playerInputActions.Player.BarkToFollow.WasPressedThisFrame();
    }

    public bool GetBarkToInteractInput()
    {
        return playerInputActions.Player.BarkToInteract.WasPressedThisFrame();
    }

    public bool GetPauseInput()
    {
        return playerInputActions.PauseMenu.Pause.WasPressedThisFrame();
    }
}
