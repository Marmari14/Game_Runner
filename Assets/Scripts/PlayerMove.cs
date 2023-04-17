using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float jump;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    public static int CoinCount;
    public static bool isBoost;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }

        if (Input.GetButton("Slide") && isGrounded)
        {
            anim.SetBool("slide", true);
        }
        else anim.SetBool("slide", false);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("jump", false);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("dead", true);
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            anim.SetBool("jump", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinCount++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Booster"))
        {
            isBoost = true;
            Destroy(other.gameObject);
        }
    }
}
