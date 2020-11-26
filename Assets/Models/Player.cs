using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public GameObject canvasGameOver;

    private int positionIndex = 0;

    Rigidbody2D rb;

    public void Start()
    {
        DisplayLives();
        position = transform.position;
        rb = GetComponent<Rigidbody2D>();
        canvasGameOver.SetActive(false);
    }

    private void DisplayLives()
    {
        livesText = GameObject.Find("Lives").GetComponent<Text>();
        livesText.text = "" + lives;
    }

    public void Update()
    {
        speed += 0.01f;
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

        TryEndGame();
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

    public void InflictDamage(int damage)
    {
        lives -= damage;
        if (lives < 0) 
        {
            lives = 0;
        }
        DisplayLives();
    }

    private void TryEndGame()
    {
        if (lives == 0)
        {
            speed = 0;
            timer = 0;
            canvasGameOver.SetActive(true);
        }
    }

    public void LoadMenu()
    {
        canvasGameOver.SetActive(false);
        collectedScore = 0;
        lives = 5;
        movement = 4.0f;
        speed = 50.0f;
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        canvasGameOver.SetActive(false);
        collectedScore = 0;
        lives = 5;
        movement = 4.0f;
        speed = 50.0f;
        SceneManager.LoadScene("Game");
    }
}
