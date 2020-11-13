using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarCollider : MonoBehaviour
{
    public string playerTag = "Player";
    public string captureWallTag = "CaptureWall";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            // TODO: increase player money
            Destroy(gameObject);
            Debug.Log("Detected collision with a dollar");
        }
        else if (collision.CompareTag(captureWallTag))
        {
            Destroy(gameObject);
        }
    }
}
