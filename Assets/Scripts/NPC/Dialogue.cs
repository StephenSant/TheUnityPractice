using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("NotSkyrim/NPC/Dialogue")]//this script can be found in the Component section under the option NPC/Dialogue
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    public bool showDlg;//boolean to toggle if we can see a characters dialogue box
    public int index, optionIndex;//index for our current line of dialogue and an index for a set Miscion marker of the dialogue 
    public CharacterMovement player;//object reference to the player
    //mouselook script reference for the maincamera => "I've merged it with the CharacterMovement"
    [Header("NPC Name and Dialogue")]
    public string npcName;//name of this specific NPC
    public string[] dlgText;//array for text for our dialogue
    [Header("Screen Ratio")]
    public Vector2 scr;
    #endregion

    #region Start
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();//find and reference the player object by tag
    }
    #endregion
    #region OnGUI
    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDlg)
        {
            //set up our ratio messurements for 16:9
            if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }

            //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
            GUI.Box(new Rect(0, 6 * scr.y, Screen.width, 3 * scr.y), npcName + ": " + dlgText[index]);
            //if not at the end of the dialogue or not at the options part
            if (!(index >= dlgText.Length - 1 || index == optionIndex))
            {
                //next button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Next"))
                {
                    //move dialogue array forward
                    index++;
                }
            }

            //else if we are at options
            else if (index == optionIndex)
            {
                //Accept button allows us to skip forward to the next line of dialogue
                if (GUI.Button(new Rect(13 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Accept"))
                {
                    index++;
                }
                //Decline button skips us to the end of the characters dialogue 
                if (GUI.Button(new Rect(14 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Decline"))
                {
                    index = dlgText.Length - 1;
                }
                //else we are at the end

            }
            else
            {
                //the Bye button allows up to end our dialogue
                if (GUI.Button(new Rect(15 * scr.x, 8.5f * scr.y, scr.x, 0.5f * scr.y), "Bye"))
                {
                    //close the dialogue box
                    showDlg = false;
                    //set index back to 0
                    index = 0;
                    //allow cameras mouselook to be turned back on
                    player.enabled = true;
                    //lock the mouse cursor
                    Cursor.lockState = CursorLockMode.Locked;
                    //set the cursor to being invisible 
                    Cursor.visible = false;
                }
            }
        }
        #endregion
    }
}
