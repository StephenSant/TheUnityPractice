using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    public int pointsToAdd;
    public bool ready = false;
    public bool ask = false;
    public CharacterHandler charH;

    public int tempStrength = 0, tempDexterity = 0, tempConstitution = 0, tempInteligence = 0, tempWisdom = 0, tempCharisma = 0;

    private void Start()
    {
        charH = GetComponent<CharacterHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsToAdd > 0 && !ready)
        {
            ask = true;
        }
        if (Input.GetKeyDown(KeyCode.I) && ask)
        {
            ready = true;
        }

    }

    private void OnGUI()
    {
        float scrW = Screen.width / 16,
              scrH = Screen.height / 9;
        if (!PauseMenu.paused && !Inventory.showInv)
        {
            if (ask)
            {
                GUI.Box(new Rect(0.1f * scrW, 0.6f * scrH, 2f * scrW, 0.5f * scrH), "Points Avalible!\nPress i");
            }
        }
        if (ready)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            int i = 2;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrH), "Add Points!");
            GUI.Box(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 2f * scrW, 0.5f * scrH), "Points: " + pointsToAdd);
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempStrength);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Strength");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempStrength <= 0))
                {
                    tempStrength--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.strength + tempStrength) < 10)
                {
                    tempStrength++;
                    pointsToAdd--;
                }

            }


            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.strength);
            if (charH.strength >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempDexterity);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Dexterity");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempDexterity <= 0))
                {
                    tempDexterity--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.dexterity + tempDexterity) < 10)
                {
                    tempDexterity++;
                    pointsToAdd--;
                }

            }
            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.dexterity);
            if (charH.dexterity >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempConstitution);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Constitution");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempConstitution <= 0))
                {
                    tempConstitution--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.constitution + tempConstitution) < 10)
                {
                    tempConstitution++;
                    pointsToAdd--;
                }

            }
            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.constitution);
            if (charH.constitution >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempInteligence);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Inteligence");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempInteligence <= 0))
                {
                    tempInteligence--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.inteligence + tempInteligence) < 10)
                {
                    tempInteligence++;
                    pointsToAdd--;
                }

            }
            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.inteligence);
            if (charH.inteligence >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempWisdom);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Wisdom");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempWisdom <= 0))
                {
                    tempWisdom--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.wisdom + tempWisdom) < 10)
                {
                    tempWisdom++;
                    pointsToAdd--;
                }

            }
            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.wisdom);
            if (charH.wisdom >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            GUI.Box(new Rect(6f * scrW, scrH + i * (0.5f * scrH), .5f * scrW, 0.5f * scrH), "+" + tempCharisma);
            GUI.Box(new Rect(6.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "Charisma");
            if (GUI.Button(new Rect(8f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "-"))
            {
                if (!(tempCharisma <= 0))
                {
                    tempCharisma--;
                    pointsToAdd++;
                }

            }
            if (GUI.Button(new Rect(8.25f * scrW, scrH + i * (0.5f * scrH), 0.25f * scrW, 0.5f * scrH), "+"))
            {
                if (pointsToAdd > 0 && (charH.charisma + tempCharisma) < 10)
                {
                    tempCharisma++;
                    pointsToAdd--;
                }

            }
            GUI.Box(new Rect(8.5f * scrW, scrH + i * (0.5f * scrH), 1.5f * scrW, 0.5f * scrH), "currently: " + charH.charisma);
            if (charH.charisma >= 10)
            {
                GUI.Box(new Rect(10f * scrW, scrH + i * (0.5f * scrH), 1.25f * scrW, 0.5f * scrH), "Maxed Out!");
            }
            i++;
            if (GUI.Button(new Rect(7.5f * scrW, scrH + i * (0.5f * scrH) + 10, 1f * scrW, 0.5f * scrH), "Done"))
            {
                charH.strength += tempStrength;
                charH.dexterity += tempDexterity;
                charH.constitution += tempConstitution;
                charH.inteligence += tempInteligence;
                charH.wisdom += tempWisdom;
                charH.charisma += tempCharisma;
                ask = false;
                ready = false;
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
