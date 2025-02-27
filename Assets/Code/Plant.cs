using UnityEngine;

public class Plant : MonoBehaviour
{
    public int health = 5;
    public GameObject bulletPlantPrefab;
    public Transform viTriBullet;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        anim.SetTrigger("Hit");

        if (health <= 0)
        {
            anim.SetTrigger("Hit");
            Destroy(gameObject);
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPlantPrefab, viTriBullet.position, Quaternion.identity);
    }
}
