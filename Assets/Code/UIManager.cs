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
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Level_0");
    }
}
