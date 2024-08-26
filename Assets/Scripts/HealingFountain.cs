using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : Collidable
{
    public int healAmount = 1;
    private float healCountdown = 1.0f;
    private float lastHeal;

    protected override void OnCollide(Collider2D collider)
    {
        if (collider.name != "Player")
            return;
        if (Time.time - lastHeal > healCountdown)
        {
            lastHeal = Time.time;
            GameManager.instance.player.Heal(healAmount);
        }
    }
}
