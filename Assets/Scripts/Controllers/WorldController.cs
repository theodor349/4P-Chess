using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    private void Start()
    {
        Debug.Log("Start");
        new World(15, 15, 3, 3);
    }

}
