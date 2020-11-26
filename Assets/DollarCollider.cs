using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DollarCollider : MonoBehaviour
{
    public string playerTag = "Player";
    public string captureWallTag = "CaptureWall";
    public static int collectedCoins = 0;
    public Text coinsText;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // TODO: after end of run add colected coins to number of coins from database
            Destroy(gameObject);
            collectedCoins++;
            coinsText = GameObject.Find("Coins").GetComponent<Text>();
            coinsText.text = "" + collectedCoins;
        }
        else if (collision.CompareTag(captureWallTag))
        {
            Destroy(gameObject);
        }
    }
}
