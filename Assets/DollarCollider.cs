using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // TODO: increase player money
            Destroy(gameObject);
            Debug.Log("Detected collision with dollar");
        }
        else if (collision.CompareTag("CaptureWall"))
        {
            Destroy(gameObject);
        }
    }
}
