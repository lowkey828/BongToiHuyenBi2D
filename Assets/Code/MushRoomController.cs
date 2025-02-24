using UnityEngine;

public class MushRoomController : MonoBehaviour
{
    float moveSpeed = 3f;
    bool moveToA = true;

    public Transform pointA;
    public Transform pointB;

    Animator anim;
    Rigidbody2D rb;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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

    public void KillEnemy()
    {
        anim.SetTrigger("Hit");
        rb.linearVelocity = new Vector2 (0, 3);
        Destroy(gameObject, 0.4f);
    }
}
