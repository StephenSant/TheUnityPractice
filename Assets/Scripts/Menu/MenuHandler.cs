using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;//interacts withe scene changing
using UnityEngine.UI;//interacting with GUI elements
using UnityEngine.EventSystems;// BUTTONS!
    public class MenuHandler : MonoBehaviour
    {
        #region Variables
        [Header("Options")]
        public bool showOptions;
        public Vector2[] res = new Vector2[7];
        public int resIndex;
        public bool isFullScreen;
        [Header("References")]
        public Light dirLight;
        public GameObject mainMenu, optionMenu;
        public Slider volSlider, brightSlider, ambientSlider;
        public Toggle fullScreenToggle;
        public AudioSource mainAudio;
        public Dropdown resDropdown;
        [Header("Keys")]
        public KeyCode holdingKey;
        public KeyCode forward, backward, left, right, jump, crouch, sprint, interact;
        [Header("KeyBind References")]
        public Text forwardText;
        public Text backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;
        #endregion

        private void Start()
        {
            forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
            backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
            left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
            right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
            jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
            crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "LeftControl"));
            sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
            interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));

            forwardText.text = (PlayerPrefs.GetString("Forward")); 
            backwardText.text = (PlayerPrefs.GetString("Backward"));
            leftText.text = (PlayerPrefs.GetString("Left"));
            rightText.text = (PlayerPrefs.GetString("Right"));
            jumpText.text = (PlayerPrefs.GetString("Jump"));
            crouchText.text = (PlayerPrefs.GetString("Crouch"));
            sprintText.text = (PlayerPrefs.GetString("Sprint"));
            interactText.text = (PlayerPrefs.GetString("Interact"));
        }

        public void LoadGame()//starts the game
        {
            SceneManager.LoadScene(1);
        }
        public void ToggleOptions()
        {
            OptionToggle();

        }
        bool OptionToggle()
        {
            if (showOptions)//showoptions == true;
            {
                showOptions = false;
                mainMenu.SetActive(true);
                optionMenu.SetActive(false);
                return true;
            }
            else
            {
                showOptions = true;
                mainMenu.SetActive(false);
                optionMenu.SetActive(true);

                volSlider = GameObject.Find("Sound Slider").GetComponent<Slider>();
                mainAudio = GameObject.Find("hello world").GetComponent<AudioSource>();
                volSlider.value = mainAudio.volume;

                brightSlider = GameObject.Find("Brightness Slider").GetComponent<Slider>();
                dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
                brightSlider.value = dirLight.intensity;

                ambientSlider = GameObject.Find("Ambient Light Slider").GetComponent<Slider>();
                ambientSlider.value = RenderSettings.ambientIntensity;

                resDropdown = GameObject.Find("Resolution Options").GetComponent<Dropdown>();
                fullScreenToggle = GameObject.Find("FullScreen Button").GetComponent<Toggle>();

                return false;
            }
        }
        public void Volume()
        {
            mainAudio.volume = volSlider.value;
        }
        public void Brightness()
        {
            dirLight.intensity = brightSlider.value;
        }
        public void AmbientLight()
        {
            RenderSettings.ambientIntensity = ambientSlider.value;
        }
        public void Resolution()
        {
            resIndex = resDropdown.value;
            Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
        }
        public void Windowed()
        {
            isFullScreen = fullScreenToggle.isOn;
            Screen.SetResolution((int)res[resIndex].x, (int)res[resIndex].y, isFullScreen);
        }
        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
            Debug.Log("QUIT!");
        }
        public void Save()
        {
            PlayerPrefs.SetString("Forward", forward.ToString());
            PlayerPrefs.SetString("Backward", backward.ToString());
            PlayerPrefs.SetString("Left", left.ToString());
            PlayerPrefs.SetString("Right", right.ToString());
            PlayerPrefs.SetString("Jump", jump.ToString());
            PlayerPrefs.SetString("Crouch", crouch.ToString());
            PlayerPrefs.SetString("Sprint", sprint.ToString());
            PlayerPrefs.SetString("Interact", interact.ToString());

            
            
        }

        private void OnGUI()
        {
            Event e = Event.current;
            if (forward == KeyCode.None)
            {
                if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    forward = e.keyCode;
                    holdingKey = KeyCode.None;
                    forwardText.text = forward.ToString();
                }
            }
            if (backward == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    backward = e.keyCode;
                    holdingKey = KeyCode.None;
                    backwardText.text = backward.ToString();
                }
            }
            if (left == KeyCode.None)
            {
                if(!(e.keyCode == forward || e.keyCode == backward || e.keyCode == right || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    left = e.keyCode;
                    holdingKey = KeyCode.None;
                    leftText.text = left.ToString();
                }
            }
            if (right == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == backward || e.keyCode == jump || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    right = e.keyCode;
                    holdingKey = KeyCode.None;
                    rightText.text = right.ToString();
                }
            }
            if (jump == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == backward || e.keyCode == right || e.keyCode == crouch || e.keyCode == sprint || e.keyCode == interact))
                {
                    jump = e.keyCode;
                    holdingKey = KeyCode.None;
                    jumpText.text = jump.ToString();
                }
            }
            if (crouch == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == backward || e.keyCode == jump || e.keyCode == right || e.keyCode == sprint || e.keyCode == interact))
                {
                    crouch = e.keyCode;
                    holdingKey = KeyCode.None;
                    crouchText.text = crouch.ToString();
                }
            }
            if (sprint == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == backward || e.keyCode == jump || e.keyCode == crouch || e.keyCode == right || e.keyCode == interact))
                {
                    sprint = e.keyCode;
                    holdingKey = KeyCode.None;
                    sprintText.text = sprint.ToString();
                }
            }
            if (interact == KeyCode.None)
            {
                if (!(e.keyCode == forward || e.keyCode == left || e.keyCode == backward || e.keyCode == jump || e.keyCode == crouch || e.keyCode == right || e.keyCode == sprint))
                {
                    interact = e.keyCode;
                    holdingKey = KeyCode.None;
                    interactText.text = interact.ToString();
                }
            }
        }
        public void Forward()
        {
            if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = forward;
                forward = KeyCode.None;
                forwardText.text = forward.ToString();
            }
        }
        public void Backward()
        {
            if (!(forward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = backward;
                backward = KeyCode.None;
                backwardText.text = backward.ToString();
            }
        }
        public void Left()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = left;
                left = KeyCode.None;
                leftText.text = left.ToString();
            }
        }
        public void Right()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = right;
                right = KeyCode.None;
                rightText.text = right.ToString();
            }
        }
        public void Jump()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = jump;
                jump = KeyCode.None;
                jumpText.text = jump.ToString();
            }
        }
        public void Crouch()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || sprint == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = crouch;
                crouch = KeyCode.None;
                crouchText.text = crouch.ToString();
            }
        }
        public void Sprint()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || interact == KeyCode.None))
            {
                holdingKey = sprint;
                sprint = KeyCode.None;
                sprintText.text = sprint.ToString();
            }
        }
        public void Interact()
        {
            if (!(forward == KeyCode.None || backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || crouch == KeyCode.None || sprint == KeyCode.None))
            {
                holdingKey = interact;
                interact = KeyCode.None;
                interactText.text = interact.ToString();
            }
        }

    }
