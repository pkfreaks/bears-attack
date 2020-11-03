using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 position;

    public float movement = 4.0f;
    public float speed = 50.0f;

    private int positionIndex = 0;

    Rigidbody2D rb;

    public void Start()
    {
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {

        rb.velocity = new Vector2(speed / 100, 0);
        if (Input.GetKeyDown(KeyCode.UpArrow) && positionIndex < 1)
        {
            MoveUp();

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && positionIndex > -1)
        {
            MoveDown();

        }

    }

    private void MoveUp()
    {
        ++positionIndex;
        position = new Vector2(transform.position.x, transform.position.y + movement);
        rb.MovePosition(position);
    }

    private void MoveDown()
    {
        --positionIndex;
        position = new Vector2(transform.position.x, transform.position.y - movement);
        rb.MovePosition(position);
    }
}
