using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10.0f;
    [SerializeField]
    private float jumpSpeed = 30.0f;
    [SerializeField]
    private GroundCheck GroundCheck = null;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private bool isPlayer1 = true;

    public bool IsPlayer1
    {
        get { return isPlayer1; }
    }

    private Rigidbody2D rigidBody = null;
    private Player_Input playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;
    private float direction = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;
    
    // private Vector3 startingPosition = Vector3.zero;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerInput = new Player_Input();
        // gameObject.name.Compare("Player")
        if (isPlayer1)
        {
            moveAction = playerInput.Player.Move;
            jumpAction = playerInput.Player.Jump;
        }
        else
        {
            moveAction = playerInput.Player2.Move;
            jumpAction = playerInput.Player2.Jump;
        }
        jumpAction.performed += OnJump;
    }

    private void OnEnable()
    {
        playerInput.Enable();
        moveAction.Enable();
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
        moveAction.Disable();
        jumpAction.Disable();
    }

    void Update()
    {
       Vector2 moveInput = moveAction.ReadValue<Vector2>();
        rigidBody.linearVelocityX = moveInput.x * moveSpeed;

        if(Mathf.Abs(moveInput.x) > 0.1f)
        {
            direction = (moveInput.x > 0.0f) ? 1.0f : -1.0f;
        }
        float speed = Mathf.Abs(rigidBody.linearVelocityX);
        if (!GroundCheck.IsGrounded && rigidBody.linearVelocityY < 0.1f)
        {
            isFalling = true;
            isJumping = false;
        }
        else if (GroundCheck.IsGrounded)
        {
            isFalling = false;
        }

        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", speed);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if (GroundCheck.IsGrounded && rigidBody.linearVelocityY <= 0.01f)
        {
            rigidBody.linearVelocityY = jumpSpeed;
            isJumping = true;
            isFalling = false;
        }
    }

}
