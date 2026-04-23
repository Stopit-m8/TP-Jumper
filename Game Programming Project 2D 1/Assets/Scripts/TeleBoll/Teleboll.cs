using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Teleboll : MonoBehaviour
{
    public TransformPlayer player;
    private bool canCollide = false;

    private void OnDisable()
    {
        canCollide = false;
    }
    private void OnEnable()
    {
        beginCollide();
        waitToDestroy();
    }
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<TransformPlayer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"colliding with : {collision.gameObject.layer}");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Teleportable") && canCollide)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.TeleportClip);
            gameObject.SetActive(false);
            player.recieveBollPosition(transform.position);
        }
    }

    private void waitToDestroy()
    {
        StartCoroutine(waitForDestroy());
    }
    private void beginCollide()
    {
        StartCoroutine(BeginCollide());
    }

    IEnumerator waitForDestroy()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
    IEnumerator BeginCollide()
    {
        yield return new WaitForSeconds(0.05f);
        canCollide = true;
    }
}
