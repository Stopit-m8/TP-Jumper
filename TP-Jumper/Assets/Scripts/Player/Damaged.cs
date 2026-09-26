using UnityEngine;

public class Damaged : MonoBehaviour
{
    [SerializeField] private MovementPlayer movement;
    [SerializeField] private TrajectoryBall trajectoryBall;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            movement.isDead = true;
            trajectoryBall.canShoot = false;
            TransitionManager.instance.RestartScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Damageable"))
        {
            movement.isDead = true;
            trajectoryBall.canShoot = false;
            TransitionManager.instance.RestartScene();
        }
    }

    private void Start()
    {
        trajectoryBall.canShoot = true;
        movement.isDead = false;
    }
}
