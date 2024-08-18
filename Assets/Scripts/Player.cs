using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"); //GetAxisRaw returns an immediate 1, 0, -1, with no smoothing
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int skin)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skin];
    }
}
