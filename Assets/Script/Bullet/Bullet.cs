using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2;

    public Vector2 direction = new Vector2(0,1);

    public Vector2 velocity;

    public bool isEnemy = false;

    private void Start()
    {
        Destroy(gameObject, 3);
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        velocity = direction * speed;
    }
    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.fixedDeltaTime;

        transform.position = pos;
    }

}
