using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Header("Movimiento")]
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    [Header("Mirada")]
    public Camera playerCamera;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0f;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Bloquear el cursor al juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0f;
        float curSpeedZ = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0f;
        float yVel = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedZ);
        moveDirection.y = yVel;

        if (characterController.isGrounded)
        {
            if (Input.GetButton("Jump") && canMove)
            {
                moveDirection.y = jumpSpeed;
            }
        }
        // Aplicar gravedad
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Mover el personaje
        characterController.Move(moveDirection * Time.deltaTime);

        // Rotación de cámara y del jugador
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
