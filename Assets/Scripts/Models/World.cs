using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

    public static World instance;

    public Tile[,] tiles;
    public List<Character> characters;

    public int width;
    public int height;

    // Creates a new world
    public World(int width, int height, int cornerX, int cornerY)
    {
        instance = this;

        this.width = width;
        this.height = height;

        tiles = new Tile[width, height];
        characters = new List<Character>();

        CreateBoard(width, height, cornerX, cornerY);
        CreateCharacters();
    }

    // Creates all characters
    private void CreateCharacters()
    {
        characters.Add(new Character(GetTileAt(5, 6), Piece.BISHOP, Color.blue));
        characters.Add(new Character(GetTileAt(6, 6), Piece.BISHOP, Color.red));
        characters.Add(new Character(GetTileAt(5, 5), Piece.BISHOP, Color.green));
        characters.Add(new Character(GetTileAt(6, 5), Piece.BISHOP, Color.yellow));
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
        if(x >= width || x < 0 || y > height || y < 0)
        {
            return null;
        }

        if (!tiles[x, y].isPartOfBoard)
        {
            return null;
        }

        return tiles[x, y];
    }

}
