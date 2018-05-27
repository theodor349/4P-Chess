using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNumberOptions : MonoBehaviour {

    public GameObject[] players;
    public RectTransform playersController;
    public int childHeight = 30;
    private Dropdown dropDown;

    private void Start()
    {
        dropDown = GetComponent<Dropdown>();
        SetPlayers();
    }

    // Enables the right amount of players
    private void SetPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].SetActive(false);
        }

        for (int i = 0; i <= dropDown.value; i++)
        {
            players[i].SetActive(true);
        }

        playersController.sizeDelta = new Vector2(playersController.sizeDelta.x, childHeight * (dropDown.value + 1));
    }

    // Called when the dropdown valye changes
    public void ValueChanged()
    {
        SetPlayers();
    }

}
