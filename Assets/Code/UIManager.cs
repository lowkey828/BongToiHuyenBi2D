using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;

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
}
