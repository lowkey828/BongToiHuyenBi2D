using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    float moveSpeed = 2f;
    bool moveToB = true;

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
        if (moveToB == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointB.position) <= 0.1f)
            {
                moveToB = false;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointA.position) <= 0.1f)
            {
                moveToB = true;
            }
        }
    }
}
