using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomisationSet : MonoBehaviour
{

    #region Variables
    #region Customisation
    [Header("Texture List")]
    //Texture2D List for skin, hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex;
    public int mouthIndex;
    public int eyesIndex;
    public int clothesIndex;
    public int armourIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax;
    public int mouthMax;
    public int eyesMax;
    public int clothesMax;
    public int armourMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string charName = "Adventurer";
    #endregion
    #region Stats
    [Header("Stats")]
    //base stats
    [Range(1, 10)]
    public int strength = 1;
    [Range(1, 10)]
    public int dexterity = 1, constitution = 1, inteligence = 1, wisdom = 1, charisma = 1;
    int baseStrength, baseDexterity, baseConstitution, baseInteligence, baseWisdom, baseCharisma;
    //points to increase our stats
    public int points;
    public int startPoints = 10;
    public CharacterClass charClass = CharacterClass.Barbarian;
    #endregion
    #endregion

    #region Start
    private void Start()//in start we need to set up the following
    {
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of hair textures we need
        for (int i = 0; i < hairMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Hair_#
            Texture2D temp = Resources.Load("Character/Hair_" + i) as Texture2D;
            //add our temp texture that we just found to the hair List
            hair.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of mouth textures we need    
        for (int i = 0; i < mouthMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Mouth_#
            Texture2D temp = Resources.Load("Character/Mouth_" + i) as Texture2D;
            //add our temp texture that we just found to the mouth List
            mouth.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of eyes textures we need
        for (int i = 0; i < eyesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Eyes_#
            Texture2D temp = Resources.Load("Character/Eyes_" + i) as Texture2D;
            //add our temp texture that we just found to the eyes List
            eyes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of clothes textures we need
        for (int i = 0; i < clothesMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Clothes_#
            Texture2D temp = Resources.Load("Character/Clothes_" + i) as Texture2D;
            //add our temp texture that we just found to the clothes List
            clothes.Add(temp);
        }
        //for loop looping from 0 to less than the max amount of clothes textures we need
        for (int i = 0; i < armourMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Armour_#
            Texture2D temp = Resources.Load("Character/Armour_" + i) as Texture2D;
            //add our temp texture that we just found to the armour List
            armour.Add(temp);
        }

        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();

        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", skinIndex = 1);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Clothes", clothesIndex = 4);
        SetTexture("Armour", armourIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        points = startPoints;
    }
    #endregion

    #region SetTexture
    void SetTexture(string type, int dir)
    {
        //we need variables that exist only within this function
        //these are ints index numbers, max numbers, material index and Texture2D array of textures
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];
        //inside a switch statement that is swapped by the string name of our material
        #region Switch Material
        switch (type)
        {
            case "Skin":
                //index is the same as our skin index
                index = skinIndex;
                //max is the same as our skin max
                max = skinMax;
                //textures is our skin list .ToArray()
                textures = skin.ToArray();
                //material index 
                matIndex = 1;
                break;
            case "Mouth":
                //index is the same as our index
                index = mouthIndex;
                //max is the same as our max
                max = mouthMax;
                //textures is our list .ToArray()
                textures = mouth.ToArray();
                //material index
                matIndex = 2;
                break;
            case "Eyes":
                //index is the same as our index
                index = eyesIndex;
                //max is the same as our max
                max = eyesMax;
                //textures is our list .ToArray()
                textures = eyes.ToArray();
                //material index    
                matIndex = 3;
                break;
            case "Hair":
                //index is the same as our index
                index = hairIndex;
                //max is the same as our max
                max = hairMax;
                //textures is our list .ToArray()
                textures = hair.ToArray();
                //material index 
                matIndex = 4;
                break;
            case "Clothes":
                //index is the same as our index
                index = clothesIndex;
                //max is the same as our max
                max = clothesMax;
                //textures is our list .ToArray()
                textures = clothes.ToArray();
                //material index    
                matIndex = 5;
                break;
            case "Armour":
                //index is the same as our index
                index = armourIndex;
                //max is the same as our max
                max = armourMax;
                //textures is our list .ToArray()
                textures = armour.ToArray();
                //material index    
                matIndex = 6;
                break;
        }
        #endregion
        #region OutSide Switch
        //outside our switch statement
        //index plus equals our direction
        index += dir;
        //cap our index to loop back around if is is below 0 or above max take one
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        //Material array is equal to our characters material list
        Material[] mat = character.materials;
        //our material arrays current material index's main texture is equal to our texture arrays current index
        mat[matIndex].mainTexture = textures[index];
        //our characters materials are equal to the material array
        character.materials = mat;
        //create another switch that is goverened by the same string name of our material
        #endregion
        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                break;
            case "Hair":
                //index equals our index
                hairIndex = index;
                break;
            case "Mouth":
                //index equals our index
                mouthIndex = index;
                break;
            case "Eyes":
                //index equals our index
                eyesIndex = index;
                break;
            case "Clothes":
                //index equals our index
                clothesIndex = index;
                break;
            case "Armour":
                //index equals our index
                armourIndex = index;
                break;
        }
        #endregion
    }
    #endregion

    #region Save
    void Save()//Function called Save this will allow us to save our indexes to PlayerPrefs
    {
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex...
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);

        //SetString CharacterName
        PlayerPrefs.SetString("CharacterName", charName);

        //Saving Stats
        PlayerPrefs.SetInt("Strength", strength);
        PlayerPrefs.SetInt("Dexterity", dexterity);
        PlayerPrefs.SetInt("Constitution", constitution);
        PlayerPrefs.SetInt("Inteligence", inteligence);
        PlayerPrefs.SetInt("Wisdom", wisdom);
        PlayerPrefs.SetInt("Charisma", charisma);

        //Saving Class
        PlayerPrefs.SetString("Class", "" + charClass);
    }
    #endregion

    #region OnGUI
    private void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        float scrW = Screen.width / 16,
            scrH = Screen.height / 9;
        #region Customisation
        int i = 0;
        GUI.Box(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrH), "Customisation");

        //create an int that will help with shuffling your GUI elements under eachother
        i++;
        #region Skin
        //GUI button on the left of the screen with the contence <
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  -1 
            SetTexture("Skin", -1);
        }

        //GUI Box or Lable on the left of the screen with the contence Skin
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Skin");

        //GUI button on the left of the screen with the contence >
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            //when pressed the button will run SetTexture and grab the Skin Material and move the texture index in the direction  1
            SetTexture("Skin", 1);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        #endregion
        //set up same things for Hair, Mouth and Eyes
        #region Hair
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Hair", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Hair");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        #endregion
        #region Mouth
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Mouth", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Mouth");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);
        }
        i++;
        #endregion
        #region Eyes
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Eyes", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Eyes");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);
        }
        i++;
        #endregion
        #region Clothes
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Clothes", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Clothes");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        #endregion
        #region Armour
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {

            SetTexture("Armour", -1);
        }
        GUI.Box(new Rect(1f * scrW, scrH + i * (0.5f * scrH), 1 * scrW, 0.5f * scrH), "Armour");
        if (GUI.Button(new Rect(2f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Armour", 1);
        }
        i++;
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.5f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMax - 1));
            SetTexture("Hair", Random.Range(0, hairMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.5f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = -1);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Clothes", clothesIndex = 4);
            SetTexture("Armour", armourIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
        }
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        #endregion
        #region Character Name and Save & Play
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        charName = GUI.TextField(new Rect(11f * scrW, 1f * scrH, 1.75f * scrW, .35f * scrH), charName, 16);
        GUI.Box(new Rect(11f * scrW, 1.35f * scrH, 1.75f * scrW, 0.4f * scrH), "The " + charClass);
        //move down the screen with the int using ++ each grouping of GUI elements are moved using this
        i++;
        //GUI Button called Save and Play
        if (GUI.Button(new Rect(13.75f * scrW, scrH * 4.75f, 2 * scrW, 0.5f * scrH), "Save and Play") && points == 0)
        {


            //this button will run the save function and also load into the game level
            Save();
            SceneManager.LoadScene(2);


        }
        if (points != 0)
        {
            GUI.Box(new Rect(13.6f * scrW, scrH * 5.5f, 2.3f * scrW, .75f * scrH), "All points must be\nspent before continuing!");
        }
        #endregion
        #endregion
        #region Skills
        i = 0;
        GUI.Box(new Rect(4.1f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Skills:");
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (strength != baseStrength)
            {
                strength--;
                points++;
                if (strength <= baseStrength)
                {
                    strength = baseStrength;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Strength = " + strength);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (strength != 10 && points != 0)
            {
                strength++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (dexterity != baseDexterity)
            {
                dexterity--;
                points++;
                if (dexterity <= baseDexterity)
                {
                    dexterity = baseDexterity;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Dexterity = " + dexterity);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (dexterity != 10 && points != 0)
            {
                dexterity++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (constitution != baseConstitution)
            {
                constitution--;
                points++;
                if (constitution <= baseConstitution)
                {
                    constitution = baseConstitution;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Constitution = " + constitution);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (constitution != 10 && points != 0)
            {
                constitution++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (inteligence != baseInteligence)
            {
                inteligence--;
                points++;
                if (inteligence <= baseInteligence)
                {
                    inteligence = baseInteligence;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Inteligence = " + inteligence);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (inteligence != 10 && points != 0)
            {
                inteligence++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (wisdom != baseWisdom)
            {
                wisdom--;
                points++;
                if (wisdom <= baseWisdom)
                {
                    wisdom = baseWisdom;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Wisdom = " + wisdom);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (wisdom != 10 && points != 0)
            {
                wisdom++;
                points--;
            }
        }
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
        {
            if (charisma != baseCharisma)
            {
                charisma--;
                points++;
                if (charisma <= baseCharisma)
                {
                    charisma = baseCharisma;
                }
            }
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Chariama = " + charisma);
        if (GUI.Button(new Rect(5.5f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
        {
            if (charisma != 10 && points != 0)
            {
                charisma++;
                points--;
            }
        }
        i++;
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 1.75f * scrW, 0.5f * scrH), "Points: " + points);
        i = 0;
        GUI.Box(new Rect(7f * scrW, 1f * scrH, 2 * scrW, 0.5f * scrH), "Class");
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Barbarian"))
        {
            charClass = CharacterClass.Barbarian;
            strength = 3;
            dexterity = 1;
            constitution = 3;
            inteligence = 1;
            wisdom = 1;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Bard"))
        {
            charClass = CharacterClass.Bard;
            strength = 1;
            dexterity = 1;
            constitution = 1;
            inteligence = 1;
            wisdom = 1;
            charisma = 5;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Druid"))
        {
            charClass = CharacterClass.Druid;
            strength = 1;
            dexterity = 2;
            constitution = 1;
            inteligence = 4;
            wisdom = 1;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Monk"))
        {
            charClass = CharacterClass.Monk;
            strength = 1;
            dexterity = 1;
            constitution = 1;
            inteligence = 1;
            wisdom = 5;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Paladin"))
        {
            charClass = CharacterClass.Paladin;
            strength = 2;
            dexterity = 2;
            constitution = 3;
            inteligence = 1;
            wisdom = 1;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Ranger"))
        {
            charClass = CharacterClass.Ranger;
            strength = 1;
            dexterity = 5;
            constitution = 1;
            inteligence = 1;
            wisdom = 1;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Sorcerer"))
        {
            charClass = CharacterClass.Sorcerer;
            strength = 1;
            dexterity = 2;
            constitution = 1;
            inteligence = 2;
            wisdom = 3;
            charisma = 1;
            points = startPoints;
        }
        i++;
        if (GUI.Button(new Rect(7 * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Warlock"))
        {
            charClass = CharacterClass.Warlock;
            strength = 2;
            dexterity = 1;
            constitution = 1;
            inteligence = 2;
            wisdom = 3;
            charisma = 1;
            points = startPoints;
        }
        #region Description
        if (charClass == CharacterClass.Barbarian)
        {
            baseStrength = 3;
            baseDexterity = 1;
            baseConstitution = 3;
            baseInteligence = 1;
            baseWisdom = 1;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nBarbarians know nothing but to smash and bash.\n\nStrength + 2 | Constitution + 2");
            GUI.Box(new Rect(9f * scrW, scrH * 1.5f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Bard)
        {
            baseStrength = 1;
            baseDexterity = 1;
            baseConstitution = 1;
            baseInteligence = 1;
            baseWisdom = 1;
            baseCharisma = 5;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nBards have a way with words.\nWith the right words you can change anyones mind.\n\nCharisma + 4");
            GUI.Box(new Rect(9f * scrW, scrH * 2f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Druid)
        {
            baseStrength = 1;
            baseDexterity = 2;
            baseConstitution = 1;
            baseInteligence = 3;
            baseWisdom = 2;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nDruids learn a bit from living in the woods.\n\nDexterity + 1 | Inteligence + 3");
            GUI.Box(new Rect(9f * scrW, scrH * 2.5f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Monk)
        {
            baseStrength = 1;
            baseDexterity = 1;
            baseConstitution = 1;
            baseInteligence = 1;
            baseWisdom = 5;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nMonks are full of wisdom.\nSome might say the mind is the most powerful weapon.\n\nWisdom + 4");
            GUI.Box(new Rect(9f * scrW, scrH * 3f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Paladin)
        {
            baseStrength = 2;
            baseDexterity = 2;
            baseConstitution = 3;
            baseInteligence = 1;
            baseWisdom = 1;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nPaladins are the ideal hero.\nTough, agile and strong.\n\nStrength + 1 | Dexterity + 1 | Constitution + 2");
            GUI.Box(new Rect(9f * scrW, scrH * 3.5f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Ranger)
        {
            baseStrength = 1;
            baseDexterity = 5;
            baseConstitution = 1;
            baseInteligence = 1;
            baseWisdom = 1;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nRangers are swift.\nCan't hit what you can't see.\n\nDexterity + 4");
            GUI.Box(new Rect(9f * scrW, scrH * 4f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Sorcerer)
        {
            baseStrength = 1;
            baseDexterity = 2;
            baseConstitution = 1;
            baseInteligence = 2;
            baseWisdom = 3;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nSorcerers use magic to attack and use agility to not get hit.\n\nDexterity + 1 | Inteligence + 1 | Wisdom + 2");
            GUI.Box(new Rect(9f * scrW, scrH * 4.5f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        if (charClass == CharacterClass.Warlock)
        {
            baseStrength = 1;
            baseDexterity = 1;
            baseConstitution = 2;
            baseInteligence = 2;
            baseWisdom = 3;
            baseCharisma = 1;
            GUI.Box(new Rect(0.5f * scrW, 6 * scrH, 8 * scrW, 2.5f * scrH), "\nWarlocks use magic and can take a hit.\n\nConstitution + 1 | Inteligence + 1 | Wisdom + 2");
            GUI.Box(new Rect(9f * scrW, scrH * 5f, 0.5f * scrW, 0.5f * scrH), "<");
        }
        #endregion
        #endregion
        if (GUI.Button(new Rect(13.75f * scrW, scrH * 4f, 2 * scrW, 0.5f * scrH), "Back"))
        {
            SceneManager.LoadScene(0);
        }
    }
    #endregion

}
public enum CharacterClass
{
    Barbarian,//Roadhog
    Bard,//Lucio
    Druid,//Bastion
    Monk,//Zenyatta
    Paladin,//ReinHart
    Ranger,//Hanzo
    Sorcerer,//Moria
    Warlock//Symmetra
}
