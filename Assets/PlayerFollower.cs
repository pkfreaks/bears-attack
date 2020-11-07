using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    public Player Player;

    private Vector3 lastPlayerPosition;

    private float distanceToMove;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        lastPlayerPosition = Player.transform.position;
    }

    void Update()
    {
        distanceToMove = Player.transform.position.x - lastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        lastPlayerPosition = Player.transform.position;
    }
}
