using System;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    World world;

    // Coords
    public int x;
    public int y;

    // The color is black if false
    public bool isWhite;
    public bool isHighlighted = false;
    public Color tempColor = Color.clear;

    // Is false if not part of the board
    public bool isPartOfBoard;
    
    // Is null if there is no character on this tile
    public Character character;

    // Callback function
    Action<Tile> tileUpdated;
    
    
    public Tile(int x, int y, bool isWhite, bool isPartOfBoard, World world)
    {
        this.x = x;
        this.y = y;
        this.isWhite = isWhite;
        this.isPartOfBoard = isPartOfBoard;
        this.world = world;
    }

    // Returns its position as a vector3
    public Vector3 GetPosition()
    {
        return new Vector3(x, y, 0);
    }

    // Highlights this tile
    public void Highlight()
    {
        isHighlighted = true;
        Update();
    }

    // Removes highlighting on this tile
    public void RemoveHighlight()
    {
        isHighlighted = false;
        Update();
    }

    // Updates the tile
    private void Update()
    {
        if(tileUpdated != null)
        {
            tileUpdated(this);
        }
    }

    // Sets a temporary color for the tile
    public void SetTempColor(Color c)
    {
        tempColor = c;
        Update();
    }

    // Inlists a function to be called when the tile is updated
    public void RegistreTileUpdatedCallback(Action<Tile> callbackFunc)
    {
        tileUpdated += callbackFunc;
    }
    // Unlists a function to be called when the tile is updated
    public void UnregistreTilerUpdatedCallback(Action<Tile> callbackFunc)
    {
        tileUpdated -= callbackFunc;
    }
}
