using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRules {

    World world;

    public CharacterRules(World world)
    {
        this.world = world;
    }

    // Returns the tiles a character can move to
    public List<Tile> GetMoveableTiles(Character c)
    {
        return FindTiles(c);
    }

    // Returns the right set of moves, depending on character type
    private List<Tile> FindTiles(Character c)
    {
        switch (c.type)
        {
            case Piece.KING:
                return RulesKing(c);
            case Piece.QUEEN:
                return RulesQueen(c);
            case Piece.ROOK:
                return RulesRook(c);
            case Piece.BISHOP:
                return RulesBishop(c);
            case Piece.KNIGHT:
                return RulesKnight(c);
            case Piece.PAWN:
                return RulesPawn(c);
            default:
                Debug.LogError("No rules found for " + c.type.ToString());
                return null;
        }
    }

    // Returns true if the tiles is walkable
    private bool Walkable(Tile t, Character c)
    {
        if(t == null)
        {
            return false;
        }

        if(t.character == null)
        {
            return true;
        }

        if(t.character.color == c.color)
        {
            return false;
        }

        return true;
    }

    // Rules King
    private List<Tile> RulesKing(Character c)
    {
        Tile t = c.tile;
        List<Tile> result = new List<Tile>();

        for (int x = -1; x < 2; x++)
        {
            for (int y = -1; y < 2; y++)
            {
                if (Walkable(world.GetTileAt(t.x + x, t.y + y), c))
                {
                    result.Add(world.GetTileAt(t.x + x, t.y + y));
                }
            }
        }

        return result;
    }

    // Rules Queen
    private List<Tile> RulesQueen(Character c)
    {
        List<Tile> result = RulesRook(c);
        result.AddRange(RulesBishop(c));
        return result;
    }

    // Rules Rook
    private List<Tile> RulesRook(Character c)
    {
        Tile t = c.tile;
        List<Tile> result = new List<Tile>();

        // Up
        for (int i = 0; i < world.height; i++)
        {
            if (Walkable(world.GetTileAt(t.x, t.y + i), c))
            {
                result.Add(world.GetTileAt(t.x, t.y + i));
                if (world.GetTileAt(t.x, t.y + i).character != null)
                {
                    break;
                }
            }
        }
        // Down
        for (int i = 0; i < world.height; i++)
        {
            if (Walkable(world.GetTileAt(t.x, t.y - i), c))
            {
                result.Add(world.GetTileAt(t.x, t.y - i));
                if (world.GetTileAt(t.x, t.y - i).character != null)
                {
                    break;
                }
            }
        }
        // Left
        for (int i = 0; i < world.width; i++)
        {
            if (Walkable(world.GetTileAt(t.x - i, t.y), c))
            {
                result.Add(world.GetTileAt(t.x - i, t.y));
                if (world.GetTileAt(t.x - i, t.y).character != null)
                {
                    break;
                }
            }
        }
        // Right
        for (int i = 0; i < world.width; i++)
        {
            if(Walkable(world.GetTileAt(t.x + i, t.y), c))
            {
                result.Add(world.GetTileAt(t.x + i, t.y));
                if (world.GetTileAt(t.x + i, t.y).character != null)
                {
                    break;
                }
            }
        }

        return result;
    }

    // Rules Bishop
    private List<Tile> RulesBishop(Character c)
    {
        Tile t = c.tile;
        List<Tile> result = new List<Tile>();

        // Up Left
        for (int i = 0; i < world.width; i++)
        {
            if (Walkable(world.GetTileAt(t.x - i, t.y + i), c))
            {
                result.Add(world.GetTileAt(t.x - i, t.y + i));
                if (world.GetTileAt(t.x - i, t.y + i).character != null)
                {
                    break;
                }
            }
        }
        // Up Right
        for (int i = 0; i < world.width; i++)
        {
            if (Walkable(world.GetTileAt(t.x + i, t.y + i), c))
            {
                result.Add(world.GetTileAt(t.x + i, t.y + i));
                if (world.GetTileAt(t.x + i, t.y + i).character != null)
                {
                    break;
                }
            }
        }
        // Down Left
        for (int i = 0; i < world.width; i++)
        {
            if (Walkable(world.GetTileAt(t.x - i, t.y - i), c))
            {
                result.Add(world.GetTileAt(t.x - i, t.y - i));
                if (world.GetTileAt(t.x - i, t.y - i).character != null)
                {
                    break;
                }
            }
        }
        // Down Right
        for (int i = 0; i < world.width; i++)
        {
            if (Walkable(world.GetTileAt(t.x + i, t.y - i), c))
            {
                result.Add(world.GetTileAt(t.x + i, t.y - i));
                if (world.GetTileAt(t.x + i, t.y - i).character != null)
                {
                    break;
                }
            }
        }

        return result;
    }

    // Rules Knight
    private List<Tile> RulesKnight(Character c)
    {
        Tile t = c.tile;
        List<Tile> result = new List<Tile>();

        // Up
        if (Walkable(world.GetTileAt(t.x + 1, t.y + 2), c))
        {
            result.Add(world.GetTileAt(t.x + 1, t.y + 2));
        }
        if (Walkable(world.GetTileAt(t.x - 1, t.y + 2), c))
        {
            result.Add(world.GetTileAt(t.x - 1, t.y + 2));
        }
        // Down
        if (Walkable(world.GetTileAt(t.x + 1, t.y - 2), c))
        {
            result.Add(world.GetTileAt(t.x + 1, t.y - 2));
        }
        if (Walkable(world.GetTileAt(t.x - 1, t.y - 2), c))
        {
            result.Add(world.GetTileAt(t.x - 1, t.y - 2));
        }
        // Left
        if (Walkable(world.GetTileAt(t.x - 2, t.y + 1), c))
        {
            result.Add(world.GetTileAt(t.x - 2, t.y + 1));
        }
        if (Walkable(world.GetTileAt(t.x - 2, t.y - 1), c))
        {
            result.Add(world.GetTileAt(t.x - 2, t.y - 1));
        }
        // Right
        if (Walkable(world.GetTileAt(t.x + 2, t.y + 1), c))
        {
            result.Add(world.GetTileAt(t.x + 2, t.y + 1));
        }
        if (Walkable(world.GetTileAt(t.x + 2, t.y - 1), c))
        {
            result.Add(world.GetTileAt(t.x + 2, t.y - 1));
        }
        
        return result;
    }

    // Rules Pawn
    private List<Tile> RulesPawn(Character c)
    {
        Tile t = c.tile;
        Vector2 dir = PawnDirection(c);
        List<Tile> result = new List<Tile>();

        if (!Walkable(world.GetTileAt(t.x + (int)dir.x, t.y + (int)dir.y), c))
        {
            return result;
        }

        result.Add(world.GetTileAt(t.x + (int)dir.x, t.y + (int)dir.y));

        if (!c.haveMoved)
        {
            if (Walkable(world.GetTileAt(t.x + (int)dir.x * 2, t.y + (int)dir.y * 2), c))
            {
                result.Add(world.GetTileAt(t.x + (int)dir.x * 2, t.y + (int)dir.y * 2));
            }
        }

        return result;
    }

    // Determins what direction a panw should go
    private Vector2 PawnDirection(Character c)
    {
        Vector2 result = new Vector2();

        if (c.color == world.playerColors[0])
        {
            result.x = 1;
        }
        else if (c.color == world.playerColors[1])
        {
            result.x = -1;
        }
        else if (c.color == world.playerColors[2])
        {
            result.y = 1;
        }
        else if (c.color == world.playerColors[3])
        {
            result.y = -1;
        }

        return result;
    }
}
