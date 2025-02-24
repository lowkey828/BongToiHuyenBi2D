using UnityEngine;

public class MovingPlatfrom : MonoBehaviour
{
    float moveSpeed = 3f;
    bool moveToA = true;

    public Transform pointA;
    public Transform pointB;

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

            if (Vector2.Distance(transform.position, pointA.position) <= 0.1f)
            {
                moveToA = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointB.position) <= 0.1f)
            {
                moveToA = true;
            }
        }
    }
}
