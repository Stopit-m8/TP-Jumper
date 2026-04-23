using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float currTime = 0f;
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private TMP_Text FinishTimeText;
    [SerializeField] private TMP_Text BestText;
    [SerializeField] private Finish finishScript;
    [SerializeField] private float bestTime = 0f;
    private string levelName;
    private string key;
    private void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        key = "BestTime" + levelName;
        Debug.Log(key);
        bestTime = PlayerPrefs.GetFloat(key);
    }
    private void Update()
    {
        int minutes = Mathf.FloorToInt(currTime / 60);
        int seconds = Mathf.FloorToInt(currTime % 60);
        if (Time.timeScale != 0f)
        {
            currTime += Time.deltaTime;
            m_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (finishScript.isFinished)
        {
            FinishTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (bestTime == 0 || currTime < bestTime)
            {
                PlayerPrefs.SetFloat(key, currTime);
            }
            bestTime = PlayerPrefs.GetFloat(key);
            int bestMinutes = Mathf.FloorToInt(bestTime / 60);
            int bestSeconds = Mathf.FloorToInt(bestTime % 60);
            BestText.text = string.Format("{0:00}:{1:00}", bestMinutes, bestSeconds);
        }
    }
}
