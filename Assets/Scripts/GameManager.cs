using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //static allows for access anywhere in code

    //Assign the instance to this GameManager
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }
        PlayerPrefs.DeleteAll(); //to restart the game
        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public Weapon weapon...
    public FloatingTextManager ftManager;

    //Logic
    public int gold;
    public int exp;

    //Ensure ftManager is only used in one spot for better organization
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        ftManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += gold.ToString() + "|";
        s += exp.ToString() + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;
        //SceneManager.sceneLoaded -= LoadState (to unregister the state), unless you want the data to persist
        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change Player Skin

        //Gold and Exp
        gold = int.Parse(data[1]);
        exp = int.Parse(data[2]);
        //Change weapon level
        Debug.Log("LoadState");
    }
}
