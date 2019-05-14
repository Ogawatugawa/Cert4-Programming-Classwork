using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomisationSet : MonoBehaviour
{
    public GUISkin customSkin;
    #region Variables
    [Header("Texture Lists")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> skin = new List<Texture2D>();

    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;

    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax, mouthMax, eyesMax, armourMax, clothesMax;

    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Traveller";

    [Header("Stats")]
    public string[] statArray = new string[6];
    public int[] stats = new int[6];
    public int[] tempStats = new int[6];
    public int points = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;
    public CharacterRace charRace = CharacterRace.Human;
    public string[] selectedClass = new string[8];
    public int selectedIndex = 0;

    private int str = 0, dex = 1, con = 2, wis = 3, intel = 4, cha = 5;
    #endregion

    #region Start
    //in start we need to set up the following
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        statArray = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Sorceror", "Warlock", "Wizard" };

        #region for loop to pull textures from file
        //for loop from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }

        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(temp);
        }

        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(temp);
        }

        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(temp);
        }

        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(temp);
        }

        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(temp);
        }
        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        #endregion
    }
    #endregion

    #region SetTexture
    //Create a function that is called SetTexture it should contain a string and int
    //the string is the name of the material we are editing, the int is the direction we are changing
    void SetTexture(string type, int direction)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, maxIndex = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material
        //inside a switch statement that is swapped by the string name of our material
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                maxIndex = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                maxIndex = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                maxIndex = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                maxIndex = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Clothes":
                index = clothesIndex;
                maxIndex = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                break;
            case "Armour":
                index = armourIndex;
                maxIndex = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                break;
            default:
                break;
        }
        #region OutSide Switch
        //outside our switch statement
        //index plus equals our direction
        index += direction;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = maxIndex - 1;
        }

        if (index >= maxIndex)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        character.materials = mat;
        #endregion
        #region Set Material Switch
        //create another switch that is goverened by the same string name of our material
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
            default:
                break;
        }
        #endregion
    }
    #endregion

    #endregion

    #region Save
    //Function called Save this will allow us to save our indexes 
    void Save()
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
        //SetString CharacterName
    }
    #endregion

    #region OnGUI
    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        string[] mats = new string[6] { "Skin", "Eyes", "Mouth", "Hair", "Clothes", "Armour" };

        for (int i = 0; i < mats.Length; i++)
        {
            GUI.skin = customSkin;
            if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
            {
                SetTexture(mats[i], -1);
            }

            GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), mats[i]);

            if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
            {
                SetTexture(mats[i], 1);
            }
            GUI.skin = null;

        }

        if (GUI.Button(new Rect(0.25f * scrW, scrH + mats.Length * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
        }

        if (GUI.Button(new Rect(1.25f * scrW, scrH + mats.Length * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
            SetTexture("Hair", Random.Range(0, hairMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
        }
    }
    #region Character Name and Save & Play
    //name of our character equals a GUI TextField that holds our character name and limit of characters
    //move down the screen with the int using ++ each grouping of GUI elements are moved using this

    //GUI Button called Save and Play
    //this button will run the save function and also load into the game level
    #endregion
    #endregion
    void ChooseClass(int className)
    {
        switch (className)
        {
            case 0:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                stats[str] = 6;
                stats[dex] = 12;
                stats[con] = 9;
                stats[intel] = 12;
                stats[wis] = 13;
                stats[cha] = 12;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Cleric;
                break;
            case 3:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Druid;
                break;
            case 4:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Fighter;
                break;
            case 5:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Monk;
                break;
            case 6:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Paladin;
                break;
            case 7:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Ranger;
                break;
            case 8:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Sorceror;
                break;
            case 9:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Warlock;
                break;
            case 10:
                stats[str] = 15;
                stats[dex] = 10;
                stats[con] = 15;
                stats[intel] = 8;
                stats[wis] = 10;
                stats[cha] = 6;
                charClass = CharacterClass.Wizard;
                break;
            default:
                break;
        }
    }
}

public enum CharacterClass
{
    Barbarian, Bard, Cleric, Druid, Fighter, Monk, Paladin, Ranger, Sorceror, Warlock, Wizard
}

public enum CharacterRace
{
    Dragonborn, Dwarf, Elf, Gnome, Half_Elf, Half_Orc, Halfling, Human, Tiefling
}