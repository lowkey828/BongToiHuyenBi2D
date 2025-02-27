
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            MushRoomController enemy = collision.GetComponent<MushRoomController>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Plant"))
        {
            Plant plant = collision.GetComponent<Plant>();

            if (plant != null)
            {
                plant.TakeDamage(1);
                Destroy(gameObject);
            }
        }
    }
}
