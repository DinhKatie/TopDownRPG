using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    //Experience for monsters
    public int xpValue = 1;

    //Logic
    public float triggerLength = 0.3f; //Aggro distance, remmeber each tile is 0.16
    public float chaseLength = 1; //How long the enemy will chase
    private bool isChasing;
    private bool collidingWithPlayer; //Stops moving toward player once they are colliding
    private Transform playerTransform;
    private Vector3 startingPosition;

    //Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox; //player will take damage if they touch this hitbox
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>(); //Get the bigger hitbox
        xSpeed = 0.5f;
        ySpeed = 0.5f;
    }

    protected void FixedUpdate()
    {
        //Is the player in range?
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
                isChasing = true;

            if (isChasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            }
            else
                UpdateMotor(startingPosition - transform.position);
        }
        else
        {
            UpdateMotor(startingPosition - transform.position);
            isChasing = false;
        }

        //Check for overlap
        collidingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
                collidingWithPlayer = true;

            //Manually clean up array
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.exp += xpValue;
        GameManager.instance.ShowText("+" + xpValue + " xp", 30, Color.magenta, transform.position, Vector3.up * 50, 0.5f);
    }
}
