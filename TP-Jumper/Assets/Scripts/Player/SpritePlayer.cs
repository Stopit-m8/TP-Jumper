using UnityEngine;
using UnityEngine.InputSystem;

public class SpritePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GroundChecker groundChecker;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool isLookingRight = true;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < transform.position.x && isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = true;
        }
        else if (mousePos.x > transform.position.x && !isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("VelocityX", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("VelocityY", rb.linearVelocityY);
        animator.SetBool("isGrounded", groundChecker.isGrounded);
    }
}
