using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    World world;
    StateHandler stateHandler;

    private void Start()
    {
        world = World.instance;
        stateHandler = world.stateHandler;
    }

    private void Update()
    {
        // Selecting
        if (Input.GetMouseButtonUp(0))
        {
            stateHandler.InputLeftClick(GetTilePosUnderMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
        // Moving
        else if (Input.GetMouseButtonUp(1))
        {
            stateHandler.InputRightClick(GetTilePosUnderMouse(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
    }

    // Sets the corect clickTile position
    private Vector2 GetTilePosUnderMouse(Vector2 pos)
    {
        pos.x = Mathf.RoundToInt(pos.x);
        pos.y = Mathf.RoundToInt(pos.y);

        return pos;
    }

}
