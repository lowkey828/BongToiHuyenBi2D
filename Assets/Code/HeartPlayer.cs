
using UnityEngine;
using UnityEngine.UI;

public class HeartPlayer : MonoBehaviour
{
    public int heart = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject player;
    public UIManager manager;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        audioManager.PlayDead(audioManager.deadClip);

        heart--;

        if (heart <= 0)
        {
            manager.GameOver();
        }
    }

    public void TakeDamage2(int damage)
    {
        audioManager.PlayDead(audioManager.deadClip);

        heart -= damage;

        if (heart <= 0)
        {
            manager.GameOver();
        }
    }
}
