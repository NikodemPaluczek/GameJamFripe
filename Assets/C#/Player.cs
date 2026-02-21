using UnityEditor.Timeline;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 3f;
    private void Update()
    {
        HandleMovement();


    }

    private void HandleMovement()
    {
        Vector2 movementInput = inputSystem.MovementInput();
        Vector3 moveDir = new Vector3(movementInput.x, 0, movementInput.y);
        float moveDistance = movementSpeed * Time.deltaTime;

        float playerHeight = 2f;
        float playerRadious = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDir, moveDistance);

        if (!canMove)
        {
           // Debug.Log("cant move trying on X");
            //try to move on X
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirX, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }
            else
            {
              //  Debug.Log("cant move on X trying on Z");
                //try on z
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadious, moveDirZ, moveDistance);
                if (canMove)
                {
                    moveDir = moveDirZ;
                }
                else
                {
                 //   Debug.Log("cant move");
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir.normalized * movementSpeed * Time.deltaTime;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
        }
    }
}
