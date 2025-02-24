using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    float moveInput;
    bool isGround;

    Rigidbody2D rb;
    Animator anim;

    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        XuLyDiChuyen();
    }


    void XuLyDiChuyen()
    {
        moveInput = Input.GetAxis("Horizontal");

        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("IsRun", true);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            anim.SetBool("IsJump", true);    
        }
        else
        {
            anim.SetBool("IsJump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && rb.linearVelocity.y < 0)
        {
            MushRoomController mushRoom = collision.gameObject.GetComponent<MushRoomController>();

            if (mushRoom != null)
            {
                mushRoom.KillEnemy();
            }
        }
    }
}
