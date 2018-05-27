using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

    public static World instance;
    public StateHandler stateHandler;

    public Tile[,] tiles;
    public List<Character> characters;

    public int width;
    public int height;

    public Color[] playerColors;

    // Creates a new world
    public World(int width, int height, int cornerX, int cornerY, Color[] playerColors, int playerCount)
    {
        instance = this;
        stateHandler = new StateHandler(this);

        this.width = width;
        this.height = height;

        this.playerColors = playerColors;
        tiles = new Tile[width, height];
        characters = new List<Character>();

        CreateBoard(width, height, cornerX, cornerY);
        CreateCharacters();
    }

    // Creates all characters
    private void CreateCharacters()
    {
        characters.Add(new Character(GetTileAt(5, 6), Piece.KNIGHT, playerColors[0]));
        characters.Add(new Character(GetTileAt(6, 6), Piece.QUEEN, playerColors[1]));
        characters.Add(new Character(GetTileAt(5, 5), Piece.ROOK, playerColors[2]));
        characters.Add(new Character(GetTileAt(6, 5), Piece.PAWN, playerColors[3]));
    }

    // Creates the board
    private void CreateBoard(int width, int height, int cornerX, int cornerY)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {   
                CreateTile(width, height, x, y, cornerX, cornerY);
            }
        }
    }

    // Creates a tile
    private void CreateTile(int width, int height, int x, int y, int cornerX, int cornerY)
    {
        tiles[x, y] = new Tile(x, y, GetTileColorAt(x, y), IsPartOfBoard(width, height, x, y, cornerX, cornerY), this);
    }

    // Returns true if part of board
    private bool IsPartOfBoard(int width, int height, int x, int y, int cornerX, int cornerY)
    {
        if (x < cornerX)
        {
            if (y < cornerY)
            {
                return false;
            }
            else if (y >= height - cornerY)
            {
                return false;
            }
        }
        else if (x >= width - cornerX)
        {
            if (y < cornerY)
            {
                return false;
            }
            else if (y >= height - cornerY)
            {
                return false;
            }
        }

        return true;
    }

    // Return the color of a tile at given x y coord
    private bool GetTileColorAt(int x, int y)
    {
        if (x % 2 == 0)
        {
            if(y % 2 != 0)
            {
                return true;
            }
        }
        else
        {
            if (y % 2 == 0)
            {
                return true;
            }
        }

        return false;
    }

    // Returns a tile at a given x y corrdinate
    public Tile GetTileAt(int x, int y)
    {
        if(x >= width || x < 0 || y >= height || y < 0)
        {
            return null;
        }

        if (!tiles[x, y].isPartOfBoard)
        {
            return null;
        }

        return tiles[x, y];
    }
    // Returns a tile at a given x y corrdinate
    public Tile GetTileAt(Vector2 pos)
    {
        if (pos.x >= width || pos.x < 0 || pos.y > height || pos.y < 0)
        {
            return null;
        }

        if (!tiles[(int)pos.x, (int)pos.y].isPartOfBoard)
        {
            return null;
        }

        return tiles[(int)pos.x, (int)pos.y];
    }

}
