using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 position;

    public float movement = 4.0f;
    public float speed = 50.0f;

    public static int collectedScore = 0;
    public static int lives = 5;
    public float timer = 0;
    public Text scoreText;
    public Text livesText;

    private int positionIndex = 0;

    Rigidbody2D rb;

    public void Start()
    {
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        livesText.text = "" + lives;

        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
     
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer >= 2)
        {
            collectedScore++;
            scoreText = GameObject.Find("Score").GetComponent<Text>();
            scoreText.text = "" + collectedScore;
            timer = 0;
        }

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
