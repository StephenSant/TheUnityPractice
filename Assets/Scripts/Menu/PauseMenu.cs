using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    #region Variables
    public static bool paused;
    public bool showOptions;
    public GameObject player;
    public GameObject optionsPanel;
    public GameObject pauseMenu;
    public Slider sensitivityY;
    public Slider sensitivityX;
    #endregion

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pauseMenu = GameObject.Find("Pause Menu");
        optionsPanel = GameObject.Find("Pause Options Menu");
        paused = false;
        showOptions = false;
        pauseMenu.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("GUI Scene");
    }

    public void SenSliders()
    {
        player.GetComponent<CharacterMovement>().sensitivityX = sensitivityX.value;
        player.GetComponent<CharacterMovement>().sensitivityY = sensitivityY.value;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !showOptions)
        {
            
            TogglePause();
            
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && showOptions)
        {
            ToggleOptions();
        }
    }
    public void TogglePause()
    {
        if (paused && !showOptions && !Inventory.showInv)
        {
            Time.timeScale = 1;Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            paused = false;
            pauseMenu.SetActive(false);
        }
        else if (paused && showOptions)
        {
            ToggleOptions();
        }
        else if (!paused && !showOptions && Inventory.showInv)
        {
            Inventory.showInv = false;Time.timeScale = 1;Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            paused = true;
            pauseMenu.SetActive(true);
        }
    }
    public void ToggleOptions()
    {
        if (!showOptions)
        {
            pauseMenu.SetActive(false);
            optionsPanel.SetActive(true);
            showOptions = true;
        }
        else if (showOptions)
        {
            pauseMenu.SetActive(true);
            optionsPanel.SetActive(false);
            showOptions = false;
        }
    }
}

