using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    World world;

    // Coords
    public int x;
    public int y;

    // The color is black if false
    public bool isWhite;

    // Is false if not part of the board
    public bool isPartOfBoard;
    
    // Is null if there is no character on this tile
    public Character character;
    
    public Tile(int x, int y, bool isWhite, bool isPartOfBoard, World world)
    {
        this.x = x;
        this.y = y;
        this.isWhite = isWhite;
        this.isPartOfBoard = isPartOfBoard;
        this.world = world;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(x, y, 0);
    }



}
