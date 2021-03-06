﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  This translates input into action
 */

public class StateHandler {

    World world;
    CharacterRules characterRules;

    Character selectedCharacter;
    List<Tile> selectedTiles;

    // Turn count
    public int turnCount;

    // Tiles the character can move to
    List<Tile> moveableTiles;
    // Hold the tiles, that a player moved from and to
    Tile[] lastMoveTiles;

    public StateHandler(World world)
    {
        this.world = world;
        moveableTiles = new List<Tile>();
        lastMoveTiles = new Tile[world.playerColors.Length * 2];

        characterRules = new CharacterRules(world);
    }

    // Left click (Select character)
    public void InputLeftClick(Vector2 pos)
    {
        if (selectedCharacter == null)
        {
            SelectCharacter(pos);
        } else
        {
            if (MoveCharacter(pos))
            {
                turnCount++;
            }
        }
        
    }

    // Right click (Move character or deselect)
    public void InputRightClick(Vector2 pos)
    {
        DeselectCharacter();
    }

    // Selects a character at given pos
    private bool SelectCharacter(Vector2 pos)
    {
        Tile t = world.GetTileAt(pos);
        // Check tile
        if (t == null || t.character == null)
        {
            return false;
        }

        // Check color;
        if (t.character.color != world.playerColors[turnCount % world.playerColors.Length])
        {
            return false;
        }
        // Deselect character
        if(selectedCharacter != null)
        {
            DeselectCharacter();
        }
        // Set new character
        SelectCharacter(t.character);

        return true;
    }

    // Moves the character if posible
    private bool MoveCharacter(Vector2 pos)
    {
        Tile t = world.GetTileAt(pos);

        // Check tile
        if (t == null)
        {
            DeselectCharacter();
            return false;
        }

        // Check if it can move at all
        if (moveableTiles == null || moveableTiles.Count == 0)
        {
            SelectCharacter(pos);
            return false;
        }

        // Check to see if the character can move to there
        if (!moveableTiles.Contains(t))
        {
            // Did we want to change our selection?
            if (SelectCharacter(pos))
            {
                // Yes we did
                return false;
            }

            DeselectCharacter();
            return false;
        }

        ColorLastMove(selectedCharacter.tile, t);
        // Move the character
        selectedCharacter.Move(t);
        DeselectCharacter();
        return true;
    }

    // Selects character
    private void SelectCharacter(Character c)
    {
        selectedCharacter = c;

        FindMoveableTile();

        HighlightTiles();
    }

    // Deselects a character
    private void DeselectCharacter()
    {
        if(selectedCharacter == null)
        {
            return;
        }
        selectedCharacter = null;

        RemoveHighlightedTile();

        if (moveableTiles != null)
        {
            moveableTiles.Clear();
        }
    }

    // Highlights tiles
    private void HighlightTiles()
    {
        if (moveableTiles == null || moveableTiles.Count == 0)
        {
            return;
        }

        foreach (Tile t in moveableTiles)
        {
            t.Highlight();
        }
    }

    // Removes the highlight on highlighted tiles
    private void RemoveHighlightedTile()
    {
        if(moveableTiles == null || moveableTiles.Count == 0)
        {
            return;
        }

        foreach (Tile t in moveableTiles)
        {
            t.RemoveHighlight();
        }
    }

    // Finds the tiles the character cam move to
    private void FindMoveableTile()
    {
        moveableTiles = characterRules.GetMoveableTiles(selectedCharacter);
    }

    // Colors the tiles a player moved from and to
    public void ColorLastMove(Tile from, Tile to)
    {
        int n1 = turnCount % world.playerColors.Length;
        int n2 = turnCount % world.playerColors.Length + world.playerColors.Length;

        // Moved from
        if (lastMoveTiles[n1] != null)
        {
            lastMoveTiles[n1].SetTempColor(Color.clear);
        }
        lastMoveTiles[n1] = from;

        // Moved to
        if (lastMoveTiles[n2] != null)
        {
            lastMoveTiles[n2].SetTempColor(Color.clear);
        }
        lastMoveTiles[n2] = to;

        // Set new Colors
        from.SetTempColor(world.playerColors[n1]);
        to.SetTempColor(world.playerColors[n1]);
    }

}
