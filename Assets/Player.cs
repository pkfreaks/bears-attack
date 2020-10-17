using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 position;

    public float movement = 4.0f;
    public float speed = 50.0f;

    private int positionIndex = 0;

    public void Start()
    {
        position = transform.position;
    }

    public void Update()
    {
        MoveTowardsPosition();
        if (ShouldMoveUp())
        {
            MoveUp();
        }
        else if (ShouldMoveDown())
        {
            MoveDown();
        }
    }

    private void MoveTowardsPosition() { transform.position = Vector2.MoveTowards(transform.position, position, speed * Time.deltaTime); }

    private bool ShouldMoveUp() { return Input.GetKeyDown(KeyCode.UpArrow) && positionIndex < 1; }

    private bool ShouldMoveDown() { return Input.GetKeyDown(KeyCode.DownArrow) && positionIndex > -1; }

    private void MoveUp()
    {
        ++positionIndex;
        position = new Vector2(transform.position.x, transform.position.y + movement);
    }

    private void MoveDown()
    {
        --positionIndex;
        position = new Vector2(transform.position.x, transform.position.y - movement);
    }
}
