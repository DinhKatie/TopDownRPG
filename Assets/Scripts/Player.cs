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

        DontDestroyOnLoad(gameObject);
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

    public void OnLevelUp()
    {
        //Get all HP back
        maxHitPoints++;
        hitPoints = maxHitPoints;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();
    }

    public void Heal(int healAmount)
    {  
        hitPoints += healAmount;
        if (hitPoints > maxHitPoints)
            hitPoints = maxHitPoints;
        GameManager.instance.ShowText("+" + healAmount.ToString() + " hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);

    }
}
