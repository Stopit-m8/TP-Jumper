using TMPro;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    [SerializeField] private TMP_Text[] bestTimeLevel;
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            string key = "BestTimeLevel" + (i + 1);
            Debug.Log(key);
            int bestMinutes = Mathf.FloorToInt(PlayerPrefs.GetFloat(key) / 60);
            int bestSeconds = Mathf.FloorToInt(PlayerPrefs.GetFloat(key) % 60);
            bestTimeLevel[i].text = string.Format("Best Time = {0:00}:{1:00}", bestMinutes, bestSeconds);
        }
    }
    public void Level1()
    {
        TransitionManager.instance.StartScene(2);
    }
    public void Level2()
    {
        TransitionManager.instance.StartScene(3);
    }
    public void Level3()
    {
        TransitionManager.instance.StartScene(4);
    }
    public void BackToMainMenu()
    {
        TransitionManager.instance.StartPrevScene();
    }
}
