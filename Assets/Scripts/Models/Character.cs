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

        tile.character = this;
    }

    // Kills the character
    public void Die()
    {
        Update(true);
    }

    // Moves the character
    public void Move(Tile t)
    {
        tile.character = null;
        tile = t;

        // If there is a character at the destination, kill it
        if(t.character != null)
        {
            t.character.Die();
        }

        t.character = this;

        haveMoved = true;

        Update();
    }

    // Updates the character
    private void Update(bool wasKilled = false)
    {
        if (characterUpdated != null)
        {
            characterUpdated(this, wasKilled);
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
