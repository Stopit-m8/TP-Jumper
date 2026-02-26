using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
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
            Debug.Log("penis");
            rb.linearVelocity = new Vector2(rb.linearVelocityX, rb.linearVelocityY * jumpPower);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.normalized.x * speed, rb.linearVelocityY);
    }
}
