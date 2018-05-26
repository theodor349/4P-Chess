using System;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    World world;

    // Prifab
    public GameObject tilePrefab;
    // Colors
    public Color whiteColor;
    public Color blackColor;
    public Color highlightedColor;
    public Color highlightedEnemyColor;

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


        tileGameobjectMap.Add(t, go);
        t.RegistreTileUpdatedCallback(TileUpdated);
        SetColor(t);
    }

    // Sets the color of the tile
    private void SetColor(Tile t)
    {
        SpriteRenderer rendere = tileGameobjectMap[t].GetComponent<SpriteRenderer>();

        // Is it highlighted
        if (!t.isHighlighted)
        {
            if (t.isWhite)
            {
                rendere.color = whiteColor;
            }
            else
            {
                rendere.color = blackColor;
            }
        }
        else
        {
            // Is there an enemy on that tile
            if(t.character != null)
            {
                rendere.color = highlightedEnemyColor;
            }
            else
            {
                rendere.color = highlightedColor;
            }
        }
    }

    // Runs when a tile is updated
    public void TileUpdated(Tile t)
    {
        SetColor(t);
    }

}
