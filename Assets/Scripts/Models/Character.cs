using System;
using System.Collections.Generic;
using UnityEngine;

public enum Piece { KING, QUEEN, ROOK, BISHOP, KNIGHT, PAWN}
public class Character {

    public Tile tile;
    public Color color;
    public Piece type;
    public bool haveMoved = false;

    // Action that is call when the character is updated
    public Action<Character, bool> characterUpdated;

    public Character(Tile tile, Piece type, Color color)
    {
        this.tile = tile;
        this.type = type;
        this.color = color;
    }

    // Kills the character
    public void Kill()
    {
        Update(); 
    }

    // Moves the character
    public void Move(Tile t)
    {
        tile.character = null;
        tile = t;
        t.character = this;

        Update();
    }

    // Updates the character
    private void Update()
    {
        if (characterUpdated != null)
        {
            characterUpdated(this, true);
        }
    }

    // Inlists a function to be called when the character is updated
    public void RegistreCharacterUpdatedCallback(Action<Character, bool> callbackFunc)
    {
        characterUpdated += callbackFunc;
    }
    // Unlists a function to be called when the character is updated
    public void UnregistreCharacterUpdatedCallback(Action<Character, bool> callbackFunc)
    {
        characterUpdated -= callbackFunc;
    }

}
