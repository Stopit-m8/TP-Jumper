using UnityEngine;

public class FinishCanvas : MonoBehaviour
{
    public void RestartLevel()
    {
        TransitionManager.instance.RestartScene();
    }
    public void SelectLevel()
    {
        TransitionManager.instance.StartScene(1);
    }
}
