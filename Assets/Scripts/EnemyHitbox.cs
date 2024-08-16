using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damagePoint = 1;
    public float pushForce = 5;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.tag == "Fighter" && collider.name == "Player")
        {
            //Create a new damage object before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            collider.SendMessage("ReceiveDamage", dmg);
        }
    }
}
