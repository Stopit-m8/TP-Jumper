using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpExtra;
    private float jumpCount;
    [SerializeField] private GroundChecker groundChecker;
    private Rigidbody2D rb;
    private Vector2 dir;
    public bool isDead;

    private void Start()
    {
        jumpCount = jumpExtra;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && jumpCount > 0 && isDead == false)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
            jumpCount--;
        }
    }
    private void Update()
    {
        if (groundChecker.isGrounded)
        {
            jumpCount = jumpExtra;
        }
    }


    private void FixedUpdate()
    {
        if (isDead == false)
        {
            rb.linearVelocity = new Vector2(dir.normalized.x * speed, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        
    }
}
