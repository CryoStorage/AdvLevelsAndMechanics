using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float lookSpeed = 2.0f;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private Vector2 smoothLook;
    private float smoothLookSpeed = 10.0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // Move the character
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;
        controller.Move(moveDirection * Time.deltaTime);

        // Rotate the character
        smoothLook.x += lookInput.x * lookSpeed;
        smoothLook.y += lookInput.y * lookSpeed;
        smoothLook.y = Mathf.Clamp(smoothLook.y, -90, 90);
        transform.localRotation = Quaternion.AngleAxis(smoothLook.x, Vector3.up);
        Camera.main.transform.localRotation = Quaternion.AngleAxis(-smoothLook.y, Vector3.right);
    }
}