using Unity.VisualScripting;
using UnityEngine;

public class PlantPullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HeartPlayer player = collision.GetComponent<HeartPlayer>();

            if (player != null)
            {
                player.TakeDamage2(1);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
