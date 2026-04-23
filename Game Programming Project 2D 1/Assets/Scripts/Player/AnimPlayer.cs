using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GroundChecker groundChecker;

    private void Update()
    {
        animator.SetFloat("VelocityX",Mathf.Abs(rb.linearVelocityX));
        animator.SetFloat("VelocityY",Mathf.Abs(rb.linearVelocityY));
        animator.SetBool("isGrounded", groundChecker.isGrounded);
    }
}
