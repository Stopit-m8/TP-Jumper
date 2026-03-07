using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleboll : MonoBehaviour
{
    public TransformPlayer player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<TransformPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
            player.recieveBollPosition(transform.position);
        }
    }

    private void Update()
    {
        waitToDestroy();
    }

    private void waitToDestroy()
    {
        StartCoroutine(waitForDestroy());
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
