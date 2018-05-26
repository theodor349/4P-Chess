using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public Color[] playerColors;

    private void Start()
    {
        new World(15, 15, 3, 3, playerColors);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            World.instance.characters[0].Die();
        }
    }

}
