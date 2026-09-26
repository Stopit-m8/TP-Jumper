using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject setting;
    [SerializeField] private GameObject mainMenu;
    public void play()
    {
        TransitionManager.instance.StartNextScene();
    }
    public void OpenCloseSettings()
    {
        if (setting.activeInHierarchy)
        {
            setting.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            setting.SetActive(true);
            mainMenu.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
