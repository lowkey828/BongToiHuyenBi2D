using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerWin : MonoBehaviour
{
    public TextMeshProUGUI winScoreText;
    public TextMeshProUGUI MaxScoreText;

    AudioManager audioManager;

    void Start()
    {
        audioManager.PlayWin(audioManager.winClip);

        int scoreScene1 = PlayerPrefs.GetInt("ScoreScene1", 0);
        int scoreScene2 = PlayerPrefs.GetInt("ScoreScene2", 0);
        int scoreScene3 = PlayerPrefs.GetInt("ScoreScene3", 0);

        int tongScore = scoreScene1 + scoreScene2 + scoreScene3;

        int maxScore = PlayerPrefs.GetInt("MaxScore", 0);

        if (tongScore > maxScore)
        {
            PlayerPrefs.SetInt("MaxScore", tongScore);
            PlayerPrefs.Save();
        }

        maxScore = PlayerPrefs.GetInt("MaxScore", 0);

        winScoreText.text = "Điểm của bạn: " + tongScore.ToString();
        MaxScoreText.text = "Điểm cao nhất: " + maxScore.ToString();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
