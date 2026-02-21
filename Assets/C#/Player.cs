using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] GameObject hp3;
    [SerializeField] GameObject hp2;
    [SerializeField] GameObject hp1;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 5f;
    public int playerHealth = 3;
    private void Update()
    {
        HandleMovement();
    }
    public void UpdateHealth(int health)
    {
        playerHealth = Mathf.Clamp(playerHealth + health, 0, 3);
        if(playerHealth == 3)
        {
            hp3.SetActive(true);
        }
        else if (playerHealth == 2)
        {
            hp2.SetActive(true);
            hp3.SetActive(false);
        }
        else if (playerHealth == 1)
        {
            hp2.SetActive(false);
            hp3.SetActive(false);
            hp1.SetActive(true);
        }
        if (health == 0)
        {
            hp2.SetActive(false);
            hp3.SetActive(false);
            hp1.SetActive(false);
        }
    }

    private void HandleMovement()
    {
        Vector2 movementInput = inputSystem.MovementInput();
        Vector3 moveDir = new Vector3(movementInput.x, 0, movementInput.y);
        float moveDistance = movementSpeed * Time.deltaTime;

        transform.position += moveDir.normalized * movementSpeed * Time.deltaTime;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotationSpeed * Time.deltaTime);
    }
}
