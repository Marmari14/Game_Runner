using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private GameManager gm;
    public static bool isCollision = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isCollision)
        {
            Destroy(gameObject, 6);
            rb.velocity = Vector2.left * (speed + gm.speedMultiplier);
        }
        else rb.velocity = Vector2.left*0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isCollision = true;
    }
}
