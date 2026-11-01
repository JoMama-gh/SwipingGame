using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Liikkumisasetukset")]
    public float walkSpeed = 5.0f;
    public float sprintSpeed = 8.0f;
    public float jumpForce = 7.0f;
    public float gravity = 20.0f;

    [Header("Kameran asetukset")]
    public Camera playerCamera;
    public float lookSpeed = 15.0f;
    public float lookXLimit = 85.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current == null || Mouse.current == null) return;

        if (canMove && playerCamera != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            transform.Rotate(0, mouseDelta.x * lookSpeed * Time.deltaTime, 0);

            rotationX -= mouseDelta.y * lookSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }

        Vector2 moveInput = Vector2.zero;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveInput.y = 1;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveInput.y = -1;
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveInput.x = 1;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveInput.x = -1;

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isSprinting = Keyboard.current.leftShiftKey.isPressed;
        float curSpeedX = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * moveInput.y : 0;
        float curSpeedY = canMove ? (isSprinting ? sprintSpeed : walkSpeed) * moveInput.x : 0;

        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (characterController.isGrounded)
        {
            moveDirection.y = -0.5f;

            if (canMove && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y = movementDirectionY;
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}