using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Transform back_Transform;
    private float back_Size;
    private float back_pos;
    public static float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        back_Transform = GetComponent<Transform>();
        back_Size = GetComponent<SpriteRenderer>().bounds.size.x;
        scrollSpeed = -3f;
    }

    // Update is called once per frame
    void Update()
    {
        back_pos += scrollSpeed * Time.deltaTime;
        back_pos = Mathf.Repeat(back_pos, back_Size);
        back_Transform.position = new Vector3(back_pos, 0, 0);
    }
}
