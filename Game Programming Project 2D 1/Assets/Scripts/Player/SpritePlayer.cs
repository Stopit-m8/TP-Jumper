using UnityEngine;

public class SpritePlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
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
        if (rb.linearVelocityX < -0.1 && isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = true;
        }
        else if (rb.linearVelocityX > 0.1 && !isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("VelocityX", Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("VelocityY", rb.linearVelocityY);
    }
}
