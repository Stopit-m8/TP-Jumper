using UnityEngine;
using UnityEngine.InputSystem;

public class TrajectoryBall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float launchPower;
    private LineRenderer line;
    private Camera cam;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    public void MouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            ShowLine();
            Debug.Log("munir");
        }
        if (ctx.canceled)
        {
            SpawnBall();
            HideLine();
        }
    }

    void ShowLine()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        line.positionCount = 2;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, mousePos);
    }

    void HideLine()
    {
        line.positionCount = 0;
    }

    void SpawnBall()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;

        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ball.GetComponent<Rigidbody2D>().linearVelocity = direction * launchPower;
    }
}
