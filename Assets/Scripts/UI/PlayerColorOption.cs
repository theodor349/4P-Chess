using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorOption : MonoBehaviour {

    public Image image;
    public Dropdown dropDown;
    public PlayerColorOption[] playerColorsOpntions;

    private Color[] colors = { Color.green, Color.blue, Color.red, Color.yellow };
    private int value = 0;
    private bool changing = false;

    private void Start()
    {
        playerColorsOpntions = FindObjectsOfType<PlayerColorOption>();

        SetColors();
    }

    public void SetColors()
    {
        List<string> options = new List<string>();

        dropDown.ClearOptions();
        options.Add("Green");
        options.Add("Blue");
        options.Add("Red");
        options.Add("Yellow");

        dropDown.AddOptions(options);

        value = FindValue();
        dropDown.value = value;
        image.color = colors[value];
    }

    // Find the correct value for this object
    private int FindValue()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            bool taken = false;
            for (int j = 0; j < playerColorsOpntions.Length; j++)
            {
                if (playerColorsOpntions[j].value == i)
                {
                    taken = true;
                }
            }

            if (!taken)
            {
                return i;
            }
        }

        return 0;
    }

    // Changes this color if another have changed to it
    public void OtherValueChanged(Vector2 other)
    {
        changing = true;
        if(other.y == value)
        {
            ChangeColor((int)other.x);
            dropDown.value = value;
        }
        changing = false;
    }

    // Is called id the dropdown changes value
    public void ValueChanged()
    {
        if (changing)
        {
            return;
        }

        for (int i = 0; i < playerColorsOpntions.Length; i++)
        {
            if(playerColorsOpntions[i] == this)
            {
                continue;
            }
            playerColorsOpntions[i].OtherValueChanged(new Vector2(value, dropDown.value));
        }
        ChangeColor(dropDown.value);
    }


    // Updates the color
    private void ChangeColor(int i)
    {
        value = i;
        image.color = colors[value];
    }
}
