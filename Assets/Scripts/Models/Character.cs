using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Piece { KING, QUEEN, ROOK, BISHOP, KNIGHT, PAWN}
public class Character {

    public Tile tile;
    public Color color;
    public Piece type;
    public bool haveMoved = false;

    public Character(Tile tile, Piece type, Color color)
    {
        this.tile = tile;
        this.type = type;
        this.color = color;
    }

}
