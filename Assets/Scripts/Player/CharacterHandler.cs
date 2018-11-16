using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//this script can be found in the Component section under the option Character Set Up 
//Character Handler
[AddComponentMenu("NotSkyrim/Player/PlayerHandler")]
public class CharacterHandler : MonoBehaviour
{
    #region Variables
    #region Character
    [Header("Character")]
    public bool alive = true;//bool to tell if the player is alive
    //connection to players character controller
    public CharacterController controller;
    public CharacterMovement movement;
    public CheckPoint checkPoint;
    #endregion
    #region Health
    [Header("Health")]
    public static float maxHealth;//max health
    public static float curHealth;//current health
    public GUIStyle healthColor;
    public GUIStyle healthColorBackground;
    //public bool isHealing;//When is it going start healing?
    //public float startHealTime = 10;
    //public float healTimer;
    #endregion
    #region Level and Exp
    [Header("Levels and Exp")]
    //players current level
    public int level;
    //max and current experience
    public int maxExp, curExp;
    public GUIStyle expColor, expColorBackground;
    public LevelUp levelUp;
    #endregion
    #region MiniMap
    [Header("Camera Connection")]
    //render texture for the mini map that we need to connect to a camera
    public RenderTexture miniMap;
    #endregion
    #region Stats
    [Header("Stats")]
    [Range(1, 10)]
    public int strength = 1;
    [Range(1, 10)]
    public int dexterity = 1, constitution = 1, inteligence = 1, wisdom = 1, charisma = 1;
    public CharacterClass charClass = CharacterClass.Paladin;
    #endregion
    #endregion
    #region Start
    private void Start()
    {

        //make sure player is alive
        alive = true;
        //connect the Character Controller to the controller variable
        controller = GetComponent<CharacterController>();
        movement = GetComponent<CharacterMovement>();
        checkPoint = GetComponent<CheckPoint>();
        levelUp = GetComponent<LevelUp>();

        maxHealth = 100 * constitution;
        //set current health to max
        curHealth = maxHealth;
        movement.runSpeed = 7 + dexterity;
        LoadStats();
        //healTimer = startHealTime;

    }
    #endregion
    #region LoadStats
    void LoadStats()
    {
        strength = PlayerPrefs.GetInt("Strength", 5);
        dexterity = PlayerPrefs.GetInt("Dexterity", 5);
        constitution = PlayerPrefs.GetInt("Constitution", 5);
        inteligence = PlayerPrefs.GetInt("Inteligence", 5);
        wisdom = PlayerPrefs.GetInt("Wisdom", 5);
        charisma = PlayerPrefs.GetInt("Charisma", 5);

        charClass = (CharacterClass)System.Enum.Parse(typeof(CharacterClass), PlayerPrefs.GetString("Class", "Paladin"));
        //grab the gameObject in scene that is our character and set its Object name to the Characters name
        gameObject.name = PlayerPrefs.GetString("CharacterName");
    }
    #endregion
    #region Update
    private void Update()
    {
        //if our current experience is greater or equal to the maximum experience
        if (curExp >= maxExp)
        {
            //then the current experience is equal to our experience minus the maximum amount of experience
            curExp -= maxExp;
            //our level goes up by one
            level++;
            //the maximum amount of experience is increased by 50
            maxExp += 50;
            levelUp.pointsToAdd++;
        }
        /*healTimer -= Time.deltaTime;
        if (healTimer <= 0)
        {
            isHealing = true;
            healTimer = 0;
        }
        else
        {
            isHealing = false;
        }*/

    }
    #endregion
    #region LateUpdate
    private void LateUpdate()
    {
        /*if (isHealing)
        {
            curHealth+=.1f;
        }*/
        //if our current health is greater than our maximum amount of health
        if (curHealth > maxHealth)
        {
            //then our current health is equal to the max health
            curHealth = maxHealth;
        }
        //if our current health is less than 0 or we are not alive
        if (curHealth < 0 || !alive)
        {
            //current health equals 0
            curHealth = 0;
        }

        if (curHealth == 0)
        {
            Die();
        }

    }
    #endregion
    #region Die
    private void Die()
    {
        transform.position = checkPoint.curCheckpoint.transform.position;//our transform.position is equal to that of the checkpoint
        curHealth = maxHealth;//our characters health is equal to full health
        alive = true;//character is alive
        controller.enabled = true;//characters controller is active 
    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        //set up our aspect ratio for the GUI elements
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        if (!PauseMenu.paused)
        {

            //GUI Box on screen for the healthbar background
            GUI.Box(new Rect(scrW * 6, scrH * 0.25f, scrW * 4, scrH * 0.5f), "", healthColorBackground);
            //GUI Box for current health that moves in same place as the background bar
            //current Health divided by the posistion on screen and timesed by the total max health
            GUI.Box(new Rect(scrW * 6, scrH * 0.25f, curHealth * (scrW * 4) / maxHealth, scrH * 0.5f), "", healthColor);

            //GUI Box on screen for the experience background
            GUI.Box(new Rect(scrW * 6, scrH * 0.75f, scrW * 4, scrH * 0.25f), "", expColorBackground);
            //GUI Box for current experience that moves in same place as the background bar
            //current experience divided by the posistion on screen and timesed by the total max experience
            GUI.Box(new Rect(scrW * 6, scrH * 0.75f, curExp * (scrW * 4) / maxExp, scrH * 0.25f), "", expColor);
            //stamia
            GUI.Box(new Rect(scrW * 15.75f, scrH * 0.25f, scrW * 0.25f, scrH * 2), "", expColorBackground);
            GUI.Box(new Rect(scrW * 15.75f, scrH * 2.25f, scrW * 0.25f, movement.stamina * (scrH * -2) / movement.staminaCap), "", expColor);
            if (!Inventory.showInv)
            {
                //GUI Draw Texture on the screen that has the mini map render texture attached 
                GUI.Box(new Rect(13.75f * scrW, 0.25f * scrH, 2 * scrW, 2 * scrH), miniMap);

                //Cursor in center point
                GUI.Box(new Rect(scrW * 8, scrH * 4.5f, scrW * 0.1f, scrH * 0.1f), "");
            }
        }
    }

    #endregion

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<DamageOnTouch>())
        {
            curHealth -= other.gameObject.GetComponent<DamageOnTouch>().damage;
            //healTimer = startHealTime;
        }
    }
}










