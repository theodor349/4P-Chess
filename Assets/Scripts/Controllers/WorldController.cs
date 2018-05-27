using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    private void Start()
    {
        new World(15, 15, 3, 3, Data.colors, Data.playerCount);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            World.instance.characters[0].Die();
        }
    }

}
