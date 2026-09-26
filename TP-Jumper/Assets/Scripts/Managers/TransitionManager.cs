using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    IEnumerator NextSceneTransition()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("Enter");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        animator.SetTrigger("Out");
        Time.timeScale = 1f;
    }

    IEnumerator PrevSceneTransition()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("Enter");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        animator.SetTrigger("Out");
        Time.timeScale = 1f;
    }

    IEnumerator SceneTransition(int index)
    {
        Time.timeScale = 1f;
        animator.SetTrigger("Enter");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(index);
        animator.SetTrigger("Out");
        Time.timeScale = 1f;
    }

    IEnumerator RestartSceneTransition()
    {
        Time.timeScale = 1f;
        animator.SetTrigger("Enter");
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        animator.SetTrigger("Out");
        Time.timeScale = 1f;
    }

    public void StartScene(int index)
    {
        StartCoroutine(SceneTransition(index));
    }

    public void StartNextScene()
    {
        StartCoroutine(NextSceneTransition());
    }
    public void StartPrevScene()
    {
        StartCoroutine(PrevSceneTransition());
    }

    public void RestartScene()
    {
        StartCoroutine(RestartSceneTransition());
    }
}
