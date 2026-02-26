using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private LayerMask groundLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
