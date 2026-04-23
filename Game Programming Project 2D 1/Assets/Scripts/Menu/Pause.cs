using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject pausePanel;
    public void PauseGame(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Game Is Paused");
            if (pausePanel.activeInHierarchy || setting.activeInHierarchy)
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
                setting.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }
        }
    }
    public void PauseG()
    {
        Debug.Log("Game Is Paused");
        if (pausePanel.activeInHierarchy || setting.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            setting.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
    }

    public void OpenCloseSettings()
    {
        if (setting.activeInHierarchy)
        {
            setting.SetActive(false);
            pausePanel.SetActive(true);
        }
        else
        {
            setting.SetActive(true);
            pausePanel.SetActive(false);
        }
    }

    public void BackToLevelSelect()
    {
        TransitionManager.instance.StartScene(1);
    }
}
