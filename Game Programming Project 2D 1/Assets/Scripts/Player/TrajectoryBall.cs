using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrajectoryBall : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float launchPower;
    [SerializeField] private int lineResolution;
    private LineRenderer line;
    private Camera cam;
    private bool isHolding;

    private void Awake()
    {
        line = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    public void MouseClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isHolding = true;
        }
        if (ctx.canceled)
        {
            isHolding = false;
            SpawnBall();
            HideLine();
        }
    }

    void Update()
    {
        if (isHolding)
        {
            ShowLine();
            Debug.Log("munir");
        }
    }

    void ShowLine()
    {
        //Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0f;

        //line.positionCount = lineResolution;
        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, mousePos);

        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;
        Vector2 velocity = direction * launchPower;

        line.positionCount = lineResolution;

        Vector2 position = transform.position;
        Vector2 gravity = Physics2D.gravity;

        float timestep = 0.1f;

        for (int i = 0; i < lineResolution; i++)
        {
            float t = i * timestep;

            Vector2 predictedPosition =
                position +
                velocity * t +
                0.5f * gravity * t * t;

            line.SetPosition(i, predictedPosition);
        }
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
        GameObject ball = PoolingTeleboll.instance.getPooledObject();
        if (ball != null)
        {
            ball.transform.position = transform.position;
            ball.SetActive(true);
            ball.GetComponent<Rigidbody2D>().linearVelocity = direction * launchPower;
        }
        
    }
}
