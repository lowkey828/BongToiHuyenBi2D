
using UnityEngine;

public class MushRoomController : MonoBehaviour
{
    float moveSpeed = 3f;
    bool moveToA = true;

    public Transform pointA;
    public Transform pointB;

    public int health = 3;

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        XuLyDiChuyen();
    }

    void XuLyDiChuyen()
    {
        if (moveToA == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1);

            if (Vector2.Distance(transform.position, pointA.position) <= 0.1f)
            {
                moveToA = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1);

            if (Vector2.Distance(transform.position, pointB.position) <= 0.1f)
            {
                moveToA = true;
            }
        }
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
}
