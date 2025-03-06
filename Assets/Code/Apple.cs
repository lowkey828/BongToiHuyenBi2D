
using UnityEngine;

public class Apple : MonoBehaviour
{
    Animator anim;
    AudioManager audioManager;

    public UIManager manager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;

            anim.SetTrigger("Hit");

            if (manager != null)
            {
                manager.EatScore();
            }

            audioManager.PlayAppleSFX(audioManager.appleClip);
            Destroy(gameObject, 0.5f);
        }
    }
}
