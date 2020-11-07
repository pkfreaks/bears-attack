using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // TODO: inflict damage to a player
            Destroy(gameObject);
            Debug.Log("Detected collision with tree");
        }
        else if (collision.CompareTag("CaptureWall"))
        {
            Destroy(gameObject);
        }
    }
}
