using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  This translates input into action
 */

public class StateHandler {

    World world;

    Character selectedCharacter;
    List<Tile> selectedTiles;

    // Rounded position of where the player clicked
    Vector2 clickPos;

    public StateHandler(World world)
    {
        this.world = world;
    }

    // Left click
    public void InputLeftClick(Vector2 pos)
    {
        clickPos = pos;
    }

    // Right click
    public void InputRightClick(Vector2 pos)
    {
        clickPos = pos;
    }

}
