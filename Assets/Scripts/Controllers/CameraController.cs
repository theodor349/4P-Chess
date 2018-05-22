using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    World world;

    private void Start()
    {
        world = World.instance;
        transform.position = new Vector3(world.width / 2f, world.height / 2f - 0.5f, transform.position.z);
    }

}
