using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        foreach(FloatingText text in floatingTexts) 
        { text.UpdateFloatingText(); }
    }
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText ft = GetFloatingText();

        //Floating text's text component, getting the text attribute
        ft.txt.text = msg;
        ft.txt.fontSize = fontSize;
        ft.txt.color = color;
        ft.go.transform.position = Camera.main.WorldToScreenPoint(position); //Transfer world space to screen space to use in UI
        ft.motion = motion;
        ft.duration = duration;

        ft.Show();
    }

    private FloatingText GetFloatingText()
    {
        //find a currently hidden text
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            //Fill in its attributes
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            //Set its transform as a parent of the textContainer
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
