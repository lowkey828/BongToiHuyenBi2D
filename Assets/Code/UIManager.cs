
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;

    public GameObject gameOverPanel;

    void Start()
    {
        UpdateScoreIU();
    }

    public void EatScore()
    {
        score++;
        UpdateScoreIU();
    }

    void UpdateScoreIU()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
