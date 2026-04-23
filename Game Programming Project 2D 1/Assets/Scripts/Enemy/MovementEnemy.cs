using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject[] points;
    [SerializeField] private GameObject containerPoints;
    [SerializeField] private float speed;
    private Transform currentPos;
    private int currIndex = 0;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int indexChild = containerPoints.transform.childCount;
        points = new GameObject[indexChild];
        for (int i = 0; i < indexChild; i++)
        {
            points[i] = containerPoints.transform.GetChild(i).gameObject;
        }
        currentPos = points[0].transform;
    }

    private void Update()
    {
        Vector2 dir = (points[currIndex].transform.position - transform.position).normalized;
        if (Time.timeScale != 0f)
        {
            rb.linearVelocity = dir * speed;
        }
        
        if (Vector2.Distance(transform.position, points[currIndex].transform.position) < 0.5f)
        {
            currIndex++;
            if (currIndex >= points.Length)
            {
                currIndex = 0;
            }
        }
    }
}
