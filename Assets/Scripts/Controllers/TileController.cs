using System;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    World world;

    public GameObject tilePrefab;
    public Color whiteColor;
    public Color blackColor;

    // Dictionary that stores a relation between a gameobject and a tile
    private Dictionary<Tile, GameObject> tileGameobjectMap;

    private void Start()
    {
        world = World.instance;
        tileGameobjectMap = new Dictionary<Tile, GameObject>();

        DrawTiles();
    }

    // Will setup all the tiles
    private void DrawTiles()
    {
        for (int x = 0; x < world.width; x++)
        {
            for (int y = 0; y < world.height; y++)
            {
                DrawTile(world.tiles[x, y]);
            }
        }
    }

    // Draws a tile
    private void DrawTile(Tile t)
    {
        if (!t.isPartOfBoard)
        {
            return;
        }

        GameObject go = Instantiate(tilePrefab, t.GetPosition(), Quaternion.identity, transform);
        go.name = "Tile_" + t.x + "_" + t.y;
        if (t.isWhite)
        {
            go.GetComponent<SpriteRenderer>().color = whiteColor;
        }
        else
        {
            go.GetComponent<SpriteRenderer>().color = blackColor;
        }

        tileGameobjectMap.Add(t, go);
    }

}
