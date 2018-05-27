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
    public int playerCount;

    public Color[] playerColors;

    // Creates a new world
    public World(int width, int height, int cornerX, int cornerY, Color[] playerColors, int playerCount)
    {
        instance = this;
        stateHandler = new StateHandler(this);

        this.width = width;
        this.height = height;
        this.playerCount = playerCount;
        this.playerColors = playerColors;

        tiles = new Tile[width, height];
        characters = new List<Character>();

        CreateBoard(width, height, cornerX, cornerY);
        CreateCharacters();
    }

    // Creates all characters
    private void CreateCharacters()
    {
        Player1();

        if(playerCount >= 1)
        {
            Player2();
        }
        if(playerCount >= 2)
        {
            Player3();
        }
        if (playerCount >= 3)
        {
            Player4();
        }
    }

    // Player 1
    private void Player1()
    {
        for (int y = 3; y < 11; y++)
        {
            characters.Add(new Character(GetTileAt(1, y), Piece.PAWN, playerColors[0]));
        }
    }
    // Player 2
    private void Player2()
    {
        for (int y = 3; y < 11; y++)
        {
            characters.Add(new Character(GetTileAt(12, y), Piece.PAWN, playerColors[1]));
        }
    }
    // Player 3
    private void Player3()
    {
        for (int x = 3; x < 11; x++)
        {
            characters.Add(new Character(GetTileAt(x, 1), Piece.PAWN, playerColors[2]));
        }
    }
    // Player 4
    private void Player4()
    {
        for (int x = 3; x < 11; x++)
        {
            characters.Add(new Character(GetTileAt(x, 12), Piece.PAWN, playerColors[3]));
        }
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
