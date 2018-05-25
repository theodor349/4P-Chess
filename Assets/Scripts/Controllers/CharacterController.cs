using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    World world;

    // Dictionary linking strings to sprites representing characters
    Dictionary<string, Sprite> characterSprites;
    // Dictionary that stores a relation between a gameobject and a character
    Dictionary<Character, GameObject> characterGameobjectMap;

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
        GameObject go = Instantiate(new GameObject());
        go.transform.position = c.tile.GetPosition();
        go.transform.SetParent(transform);

        SpriteRenderer rendere = go.AddComponent<SpriteRenderer>();
        rendere.sprite = GetSprite(c);
        rendere.sortingLayerName = "Character";
        rendere.color = c.color;

        c.RegistreCharacterUpdatedCallback(UpdateCharacter);
        characterGameobjectMap.Add(c, go);
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
