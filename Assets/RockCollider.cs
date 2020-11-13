using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour
{
    public string playerTag = "Player";
    public string captureWallTag = "CaptureWall";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // TODO: inflict damage to a player
            Destroy(gameObject);
            Debug.Log("Detected collision with a rock");
        }
        else if (collision.CompareTag(captureWallTag))
        {
            Destroy(gameObject);
        }
    }
}
