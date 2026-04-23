using UnityEngine;

public class SpriteEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isLookingRight;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (rb.linearVelocityX > 0 && !isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = true;
        }
        else if (rb.linearVelocityX < 0 && isLookingRight)
        {
            isLookingRight = !isLookingRight;
            spriteRenderer.flipX = false;
        }
    }
}
