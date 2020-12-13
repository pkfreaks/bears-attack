using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextureSelector: MonoBehaviour
{
    public List<Texture2D> playerTextures = new List<Texture2D>();
    public int selected = 0;

    private IList<Character> characters;

    public void Awake()
    {
        characters = new DatabaseConnector().LoadCharacters();
        AssignSelectedTexture();
    }

    private void AssignSelectedTexture()
    {
        for (int i = 0; i < characters.Count; ++i)
        {
            if (characters[i].Active)
            {
                selected = i;
                break;
            }
        }
    }

    public Texture2D SelectedTexture { get { return playerTextures[selected]; } }

    public void NextTexture()
    {
        selected = (selected + 1) % playerTextures.Count;
        new DatabaseConnector().SetActiveCharacter(characters[selected]);
    }
}
