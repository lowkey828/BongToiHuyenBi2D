using TMPro;
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

    public Transform spawnBullet;
    public GameObject prefabBullet;
    public int soLuongBullet = 10;
    public TextMeshProUGUI bulletTxt;

    public HeartPlayer heartPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        BulletUI();
    }


    void Update()
    {
        XuLyDiChuyen();
        Shoot();
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

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.E) && soLuongBullet > 0)
        {
            soLuongBullet--;

            GameObject bullet = Instantiate(prefabBullet, spawnBullet.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();

            if (transform.localScale.x > 0)
            {
                rbBullet.linearVelocity = new Vector2(10f, 0f);
            }
            else
            {
                rbBullet.linearVelocity = new Vector2(-10f, 0f);
            }
            BulletUI();
        }
    }

    void BulletUI()
    {
        if (bulletTxt != null)
        {
            bulletTxt.text = soLuongBullet.ToString();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Spike"))
        {
            heartPlayer.TakeDamage();
        }
    }
}
