using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    InputSystem_Actions inputActions;
    [SerializeField] private FlashlighController flashlighController;
    private Vector2 movementInput;
    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        
        
        inputActions.Player.Move.Enable();
        inputActions.Player.Interact.Enable();

        inputActions.Player.Interact.performed += i => flashlighController.TryToGetNeon();

    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            flashlighController.TryToGetNeon();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            flashlighController.FlashlightOn();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            flashlighController.FlashlightOff();
        }
    }
    public Vector2 MovementInput()
    {
        movementInput = inputActions.Player.Move.ReadValue<Vector2>();
        return movementInput;
    }
}
