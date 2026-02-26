using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float jumpLimit;
    private Rigidbody2D rb;
    private Vector2 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.normalized.x * speed, rb.linearVelocityY);
    }
}
