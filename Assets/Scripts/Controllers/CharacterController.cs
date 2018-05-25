using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    World world;

    // Dictionary linking strings to sprites representing characters
    Dictionary<string, Sprite> characterSprites;
    // Dictionary that stores a relation between a gameobject and a character
    Dictionary<Character, GameObject> characterGameobjectMap;

    public GameObject gameobjectPrefab;

    private void Start()
    {
        world = World.instance;
        LoadSprites();
        DrawCharacteres();
    }

    // Draws all Characters
    private void DrawCharacteres()
    {
        characterGameobjectMap = new Dictionary<Character, GameObject>();
        foreach (Character c in world.characters)
        {
            DrawCharacter(c);
        }
    }

    // Draws a character
    private void DrawCharacter(Character c)
    {
        GameObject go = Instantiate(gameobjectPrefab);
        go.transform.position = c.tile.GetPosition();
        go.transform.SetParent(transform);
        go.name = GetName(c);

        SpriteRenderer rendere = go.AddComponent<SpriteRenderer>();
        rendere.sprite = GetSprite(c);
        rendere.sortingLayerName = "Character";
        rendere.color = c.color;

        c.RegistreCharacterUpdatedCallback(UpdateCharacter);
        characterGameobjectMap.Add(c, go);
    }

    // Returns the name for a character
    private string GetName(Character c)
    {
        string name = "";

        if(c.color == Color.red)
        {
            name += "RED";
        }
        else if(c.color == Color.green)
        {
            name += "GREEN";
        }
        else if(c.color == Color.blue)
        {
            name += "BLUE";
        }
        else if(c.color == Color.yellow)
        {
            name += "YELLOW";
        }
        else
        {
            name += "UNKNOWCOLOR";
        }
    
        name += "_";

        string type = c.type.ToString();
        name += type.Substring(0, 1);
        name += type.Substring(1).ToLower();

        return name;
    }

    // Returns the matching sprite
    private Sprite GetSprite(Character c)
    {
        return characterSprites[c.type.ToString()];
    }

    // Loads all sprites
    private void LoadSprites()
    {
        characterSprites = new Dictionary<string, Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/Characters");
        foreach (Sprite s in sprites)
        {
            characterSprites.Add(s.name, s);
        }
    }

    // Updates a character
    public void UpdateCharacter(Character c, bool wasKilled = false)
    {
        if (wasKilled)
        {
            RemoveCharacter(c);
            return;
        }

        characterGameobjectMap[c].transform.position = c.tile.GetPosition();
    }

    // Removes a character from the screen
    public void RemoveCharacter(Character c)
    {
        Destroy(characterGameobjectMap[c]);
    }

}
