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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.TeleportClip);
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
