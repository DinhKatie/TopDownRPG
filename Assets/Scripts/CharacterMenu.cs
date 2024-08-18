using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterMenu : MonoBehaviour
{
    // Text fields
    public TextMeshProUGUI levelText, hitpointText, goldText, upgradeCostText, xpText;

    //Logic
    private int currentCharacterSelection = 0;
    public Image charSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    //Character Selection
    public void onArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            //If no more character after current selection, go back to beginning of array
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;
            //If no more character after current selection, go back to beginning of array
            if (currentCharacterSelection < 0)
                currentCharacterSelection = (GameManager.instance.playerSprites.Count - 1);

            OnSelectionChanged();
        }
    }

    private void OnSelectionChanged()
    {
        charSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
    }

    //Weapon Upgrades
    public void OnUpgradeClick()
    {
        if (GameManager.instance.TryUpgradeWeapon())
            UpdateMenu();
    }

    //Update character information
    public void UpdateMenu()
    {
        //Weapon
        weaponSprite.sprite = GameManager.instance.weaponSprites[GameManager.instance.weapon.weaponLevel];
        if (GameManager.instance.weapon.weaponLevel == GameManager.instance.weaponPrices.Count)
            upgradeCostText.text = "MAX";
        else
            upgradeCostText.text = GameManager.instance.weaponPrices[GameManager.instance.weapon.weaponLevel].ToString();

        //Char Information
        hitpointText.text = GameManager.instance.player.hitPoints.ToString();
        goldText.text = GameManager.instance.gold.ToString();
        levelText.text = "Not added yet";

        //XP Bar
        xpText.text = "Not added yet";
        xpBar.localScale = new Vector3(0.5f, 0, 0);
    }
}
