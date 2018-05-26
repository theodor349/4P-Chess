using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRules {

    World world;

    public CharacterRules(World world)
    {
        this.world = world;
    }

    // Returns the tiles a character can move to
    public List<Tile> GetMoveableTiles(Character c)
    {
        List<Tile> result = new List<Tile>();

        result.Add(world.GetTileAt(10, 6));
        result.Add(world.GetTileAt(12, 6));
        result.Add(world.GetTileAt(10, 5));

        return result;
    }
}
