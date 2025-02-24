using UnityEngine;

public class Apple : MonoBehaviour
{
    Animator anim;

    public UIManager manager;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Hit");

            if (manager != null)
            {
                manager.EatScore();
            }

            Destroy(gameObject, 0.5f);
        }
    }
}
