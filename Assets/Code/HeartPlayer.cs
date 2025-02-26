using UnityEngine;
using UnityEngine.UI;

public class HeartPlayer : MonoBehaviour
{
    public int heart = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject player;
    public Transform spawnPoint;
    public UIManager manager;

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < heart; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage()
    {
        heart--;
        player.transform.position = spawnPoint.position;

        if (heart <= 0)
        {
            manager.GameOver();
        }
    }
}
