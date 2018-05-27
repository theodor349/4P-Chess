using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    public Dropdown playerNumber;


	public void OnClick()
    {
        Data.playerCount = playerNumber.value;


        SceneManager.LoadScene("Game");
    }
}
