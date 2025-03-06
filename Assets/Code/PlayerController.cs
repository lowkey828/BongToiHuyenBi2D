
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    float moveInput;
    bool isGround;
    bool isDead = false;

    Rigidbody2D rb;
    Animator anim;
    AudioManager audioManager;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform spawnBullet;
    public GameObject prefabBullet;
    //public int soLuongBullet = 10;
    //public TextMeshProUGUI bulletTxt;

    public HeartPlayer heartPlayer;
    

    Vector2 checkPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //BulletUI();

        checkPoint = transform.position;
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    void Update()
    {
        if (!isDead)
        {
            XuLyDiChuyen();
            Shoot();
        }
        else
        {
            anim.SetBool("IsRun", false);

            rb.linearVelocity = Vector2.zero;
        }
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
            audioManager.PlayJumpSFX(audioManager.jumpClip);

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
        if (Input.GetKeyDown(KeyCode.E)/* && soLuongBullet > 0*/)
        {
            //soLuongBullet--;

            audioManager.PlayBullet(audioManager.bulletPlayer);

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
            //BulletUI();
        }
    }

    //void BulletUI()
    //{
    //    if (bulletTxt != null)
    //    {
    //        bulletTxt.text = soLuongBullet.ToString();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Spike"))
        {
            heartPlayer.TakeDamage();
            Respawn();
        }

        if (collision.CompareTag("CheckPoint"))
        {
            checkPoint = transform.position;
        }
    }

    void Respawn()
    {
        if (checkPoint != null)
        {
            transform.position = checkPoint;
        }
        else
        {
            transform.position = new Vector2(0, 0);
        }

        isDead = true;
        StartCoroutine(DisableMovement(1f));
    }

    IEnumerator DisableMovement(float delay)
    {
        yield return new WaitForSeconds(delay);

        isDead = false;
    }
}
