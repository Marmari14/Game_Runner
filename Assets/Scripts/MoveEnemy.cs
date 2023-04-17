using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public float frequency;
    public float magnitude;
    Vector3 pos;
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        pos = transform.position;
    }

    void Update()
    {
        if (!SpawnObjectScript.isCollision)
        {
            pos -= transform.right * Time.deltaTime * (speed + gm.speedMultiplier);
            transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
            Destroy(gameObject, 6);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SpawnObjectScript.isCollision = true;
    }
}
