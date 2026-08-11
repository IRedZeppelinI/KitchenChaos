using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlernateAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternative.performed += InteractAlternative_performed;
    }

    private void InteractAlternative_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlernateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //if (OnInteractAction != null)
        //{
        //    OnInteractAction(this, EventArgs.Empty);
        //}
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();        

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
