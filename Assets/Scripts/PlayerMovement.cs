using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Variables")]
    private float m_currentMovementSpeed = 0f;
    private float targetMovementSpeed = 0f;
    [SerializeField]
    private float m_defaultMovementSpeed = 5f;
    [SerializeField]
    private float m_sprintMultiplier = 1.2f;
    [SerializeField]
    private float m_jumpHeight = 5f;
    [SerializeField]
    private float m_yVelocity = 0f;
    [SerializeField]
    

    [Header("Camera Variables")]
    private Camera m_camera;
    [SerializeField]
    private float m_cameraSensitivity = 1f;
    private Vector3 m_cameraPitch = Vector3.zero;

    private PlayerInput m_playerInput;
    private Vector2 moveInput;
    private Vector2 lookInput;
    [SerializeField]
    private GameObject m_playerObject;
    private CharacterController m_characterController;

    private void Start()
    {
        m_camera = Camera.main;
        m_playerInput = GetComponent<PlayerInput>();
        m_characterController = GetComponent<CharacterController>();

        m_currentMovementSpeed = m_defaultMovementSpeed;
        targetMovementSpeed = m_defaultMovementSpeed;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        GetInput();
        MovePlayer();
        MoveCamera();
        ChangeSpeed();

        
    }

    void GetInput()
    {
        moveInput = m_playerInput.actions["Move"].ReadValue<Vector2>();
        lookInput = m_playerInput.actions["Look"].ReadValue<Vector2>();
        
        if (m_playerInput.actions["Sprint"].IsPressed())
        {
            targetMovementSpeed = m_defaultMovementSpeed * m_sprintMultiplier;
        }
        else
        {
            targetMovementSpeed = m_defaultMovementSpeed;
        }

        
    }

    void MovePlayer()
    {
        if(m_characterController.isGrounded)
        {
            if (m_yVelocity < 0)
            {
                m_yVelocity = -2f; // Small negative value to keep the player grounded
            }

            if (m_playerInput.actions["Jump"].triggered && m_characterController.isGrounded)
            {
                m_yVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * m_jumpHeight);
            }
        }
        else
        {
            m_yVelocity += Physics.gravity.y * Time.deltaTime;
        }

        Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        moveDirection *= m_currentMovementSpeed;

        moveDirection.y = m_yVelocity;

        m_characterController.Move(moveDirection * Time.deltaTime);
    }

    void MoveCamera()
    {
        transform.Rotate(Vector3.up * lookInput.x * m_cameraSensitivity);
        m_cameraPitch += Vector3.left * lookInput.y * m_cameraSensitivity;

        m_cameraPitch.x = Mathf.Clamp(m_cameraPitch.x, -80f, 80f);

        m_camera.transform.localRotation = Quaternion.Euler(m_cameraPitch);
    }

    void ChangeSpeed()
    {
        m_currentMovementSpeed = Mathf.Lerp(m_currentMovementSpeed, targetMovementSpeed, 5f * Time.deltaTime);
    }
}
