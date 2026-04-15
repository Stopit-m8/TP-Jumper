using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject pausePanel;
    public void PauseGame(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("Game Is Paused");
            if (pausePanel.activeInHierarchy)
            {
                Time.timeScale = 1f;
                pausePanel.SetActive(false);
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
        if (pausePanel.activeInHierarchy)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
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
            pauseMenu.SetActive(true);
        }
        else
        {
            setting.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void BackToMainMenu()
    {
        TransitionManager.instance.StartPrevScene();
    }
}
