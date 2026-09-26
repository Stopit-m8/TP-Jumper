using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Canvas FinishCanvas;
    public bool isFinished = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FinishCanvas.gameObject.SetActive(true);
            isFinished = true;
            Time.timeScale = 0f;
        }
    }
}
