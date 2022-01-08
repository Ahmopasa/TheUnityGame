using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    // Damage
    public int damage = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            // Create a new Damage obj, before sending it to the player:
            Damage dmg = new Damage 
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}

/* # INITIAL #
 * Position : 0.07 / 0.09 / 0
 * Rotation : 0    / 0    / 0
 * Scale    : 0.7  / 0.7  / 0.7
 */

/* # END STATE #
 * Position : 0.16 / -0.025 / 0
 * Rotation : 0    / 0      / -90
 * Scale    : 0.7  / 0.7    / 0.7
 */