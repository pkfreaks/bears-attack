using UnityEngine;
using System.Collections;

public class Damage
{
    public void Inflict(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        player.InflictDamage(1);
    }
}
