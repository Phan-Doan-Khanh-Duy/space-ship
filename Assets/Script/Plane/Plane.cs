using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    Gun[] guns;

    bool moveUp;
    bool moveDown;
    bool moveRight;
    bool moveLeft;

    float speed = 6;

    bool speedUp;

    bool shoot;
    

    private void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.DownArrow);
        moveRight = Input.GetKey(KeyCode.RightArrow);
        moveLeft = Input.GetKey(KeyCode.LeftArrow);

        shoot = Input.GetKeyDown(KeyCode.Space);

        if(shoot)
        {
            shoot = false;
            foreach (Gun gun in guns)
            {
                gun.Shoot();
            }   
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = speed * Time.fixedDeltaTime;

        if (speedUp)
        {
            moveAmount *= 3;
        }

        Vector2 move = Vector2.zero;

        if (moveUp)
            move.y += moveAmount;

        if (moveDown)
            move.y -= moveAmount;

        if (moveLeft)
            move.x -= moveAmount;

        if (moveRight)
            move.x += moveAmount;

        pos += move;

        transform.position = pos;
    }

    void Start()
    {
        guns = transform.GetComponentsInChildren<Gun>();
        foreach (Gun gun in guns)
        {
            gun.isActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if(bullet != null)
        {
            if (bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }

        Destruction destruction = collision.GetComponent<Destruction>();
        if (destruction != null)
        {
                Destroy(gameObject);
                Destroy(destruction.gameObject);
            
        }
    }
}
