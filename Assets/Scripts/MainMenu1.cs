using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenu1 : MonoBehaviour
{
    public GUIStyle logoTitleStyle;//this is how you make a GUIstyle i havent connected it to anything in the script it is purely example
    public float audioSlider, brightnessSlider;//both the audio and brightness slider values which we can adjust in the options section
    public AudioSource audi;//audio source in the game

    [Header("Menu Bools")]
    public bool loadScreen;
    public bool playOptions, loadOptions, options, audioOptions, brightness, resolution, controls;//these are all of out toggles to control what screen is on and when

    [Header("Resolution")]
    public bool fullScreen;
    public bool windowed;//my specific toggles for different resolutions and also full screen vs windowed they are seperate for the toggle GUI
    public Resolution[] resolutions;
    public bool dropDown;
    private Vector2 scrollPosition = Vector2.zero;

    [Header("Controls")]
    public KeyCode forward;
    public KeyCode backward, right, left, jump, sprint, crouch, holdingKey;//these are just basic example keyCodes that i have made
    public bool canChangeKey = true;
    public bool dupeKey = false;
    private string[] keyNames = new string[7];
    private KeyCode[] keyCodes = new KeyCode[7];

    private float scrW, scrH;
    #region Controls Initialisation
    public void SetControls()
    {
        forward = KeyCode.W;//setting forward to W
        backward = KeyCode.S;//setting backward to S
        left = KeyCode.A;//setting left to A
        right = KeyCode.D;//setting right to D
        jump = KeyCode.Space;//setting jump to Space
        sprint = KeyCode.LeftShift;//settin sprint to Left Shift
        crouch = KeyCode.LeftControl;//setting crouch to Left Control

        keyCodes[0] = forward;
        keyCodes[1] = backward;
        keyCodes[2] = left;
        keyCodes[3] = right;
        keyCodes[4] = jump;
        keyCodes[5] = sprint;
        keyCodes[6] = crouch;

        keyNames = new string[7];
        keyNames[0] = "Forward";
        keyNames[1] = "Backward";
        keyNames[2] = "Left";
        keyNames[3] = "Right";
        keyNames[4] = "Jump";
        keyNames[5] = "Sprint";
        keyNames[6] = "Crouch";
    }
    #endregion
    void Start() // Use this for initialization
    {
        SetControls();

        resolutions = Screen.resolutions.Where(resolution => resolution.width >= 1024).ToArray();

        loadScreen = true;//sets the intro screen to true
        fullScreen = true;//setting full screen to true

        audi = GameObject.Find("Audio").GetComponent<AudioSource>();//find the Game object in your scene named Audio and get the audio source from it
        audioSlider = audi.volume;//set the audio slider to the same level as the audio source

        brightnessSlider = RenderSettings.ambientIntensity;//setting the brightness slider to the value of the games ambient lighting
    }

    void Update() // Update is called once per frame
    {
        if (loadScreen)//if currently on load screen
        {
            if (Input.anyKey)//and any key is pressed
            {
                Debug.Log("A key or mouse click has been detected");//show in the console that any key has been pressed
                loadScreen = false;//load to main menu
            }
        }

        if (options)
        {
            audi.volume = audioSlider;//set the audio source to the same level as the audio slider
            RenderSettings.ambientIntensity = brightnessSlider;//setting the games ambient lighting to the value of the brightness slider
        }
    }

    void OnGUI() //this section allows for you to render your GUI elements in screen
    {
        float scrW = Screen.width / 16;//setting up the width for a screen resolution of 16:9
        float scrH = Screen.height / 9;//setting up the height for a screen resolution of 16:9

        if (loadScreen) //if load screen is active
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
            GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//standard logo or title block in the upper section of the screen
            GUI.Box(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "Press AnyKey");//notification to press anykey  in the lower/middle section of the screen
        }

        if (!loadScreen)//if the load screen is no longer active
        {
            if (!(playOptions || options))//and playoptions or options arent active then show the basic main menu screen
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//standard logo ot title block in the upper section of the screen

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "Play"))//play button on the menu screen 
                {
                    playOptions = true;//if pressed then go to the play options page
                }

                if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Options"))//options buttin on the menu screen
                {
                    options = true;//if pressed then go to the options page
                }

                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Exit"))//exit button on the menu screen
                {
                    Application.Quit();//when pressed exit the games application
                    Debug.Log("Exit was pressed");//in the console show me that this button was pressed
                }
            }

            if (playOptions && !loadOptions)//inside the play options screen
            {
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
                GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//logo or title block in the upper section of the screen

                if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH, 8 * scrW, 1 * scrH), "New Game"))//allow us to load/ create a new game
                {
                    SceneManager.LoadScene(1);//load game/charater selection/ level selection
                }

                if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))//if back is pressed then
                {
                    playOptions = false;//turn off the play options
                    //allowing us to go back to our main menu
                }

                if (PlayerPrefs.HasKey("SavedGame"))//if we have save files
                {
                    if (GUI.Button(new Rect(4 * scrW, 3.5f * scrH, 8 * scrW, 1 * scrH), "Continue"))//allow us to load last game
                    {
                        string curCharacterSave = PlayerPrefs.GetString("LastCharacter");//grab the name of the last played character
                        int level = PlayerPrefs.GetInt(curCharacterSave + "levelNo");//grab the current level of the last played character					

                        SceneManager.LoadScene(level);//load the level of the last played character
                    }

                    if (GUI.Button(new Rect(4 * scrW, 5.5f * scrH, 8 * scrW, 1 * scrH), "Load"))//if load is pressed then open the load options	
                    {
                        loadOptions = true;//set the load options page to active	
                    }
                }

                if (loadOptions)//if load options are active then show	
                {
                    GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
                    GUI.Box(new Rect(2 * scrW, 0.5f * scrH, 12 * scrW, 3 * scrH), "Logo / Title");//logo or title block in the upper section of the screen

                    //this amount is purely example
                    int saveAmount = 4;//using this value as  fake amount of save files as a cheat speedy way to call files...yes this way does have issues but it effective for the example
                    string[] savedGameName = new string[saveAmount];
                    for (int i = 0; i < saveAmount; i++)
                    {
                        savedGameName[i] = PlayerPrefs.GetString("Character_" + i.ToString());
                        if (GUI.Button(new Rect(4 * scrW, 4.5f * scrH + (i * (1 * scrH)), 8 * scrW, 1 * scrH), savedGameName[i]))
                        {
                            int level = PlayerPrefs.GetInt(savedGameName[i] + "levelNo");//grab the current level of the character

                            SceneManager.LoadScene(level);//load the level of the character							
                        }
                    }

                    if (GUI.Button(new Rect(4 * scrW, 6.5f * scrH, 8 * scrW, 1 * scrH), "Back"))//if back is pressed then						
                    {
                        loadOptions = false;//turn off the load options	
                                            //allowing us to go back to our play options menu
                    }
                }
            }

            if (options)//this section will hold all of the options we can change 
            {
                //background boxes
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "");//standard back ground 
                GUI.Box(new Rect(0.25f * scrW, 0.25f * scrH, 7.625f * scrW, 8.5f * scrH), "");//right back ground block
                GUI.Box(new Rect(8.125f * scrW, 0.25f * scrH, 7.625f * scrW, 8.5f * scrH), "");//left background block

                //audio slider
                GUI.Box(new Rect(0.5f * scrW, 0.5f * scrH, 7.125f * scrW, 1f * scrH), "Audio");//title and block for audio options
                audioSlider = GUI.HorizontalSlider(new Rect(0.5f * scrW, 1f * scrH, 7.125f * scrW, 0.25f * scrH), audioSlider, 0.0F, 1.0F);//audio sliderbar
                GUI.Label(new Rect(4f * scrW, 1.125f * scrH, 0.75f * scrW, 0.25f * scrH), Mathf.FloorToInt(audioSlider * 100).ToString());// showing out 0 to 100

                //brightness slider
                GUI.Box(new Rect(0.5f * scrW, 1.5f * scrH, 7.125f * scrW, 1f * scrH), "Brightness");//title and block for brightness options
                brightnessSlider = GUI.HorizontalSlider(new Rect(0.5f * scrW, 2f * scrH, 7.125f * scrW, 0.25f * scrH), brightnessSlider, 0.0F, 1.0F);//brightness sliderbar
                GUI.Label(new Rect(4f * scrW, 2.125f * scrH, 0.75f * scrW, 0.25f * scrH), Mathf.FloorToInt(brightnessSlider * 100).ToString());// showing out 0 to 100

                //resolution
                GUI.Box(new Rect(0.5f * scrW, 2.5f * scrH, 7.125f * scrW, 6f * scrH), "Resolutions");//title and block for resolution options

                #region Resolution types
                //THE TOGGLES BELOW ARE NOT AFFECTED BY FULLSCREEN VS WINDOWED

                Rect viewRect = new Rect(1.5f * scrW, 3f * scrH, 3f * scrW, (0.35f * (resolutions.Length)) * scrH);
                Resolution currentRes = Screen.currentResolution;
                if (!dropDown)
                {
                    if (GUI.Button(new Rect(1.5f * scrW, 3f * scrH, 3f * scrW, 0.35f * scrH), currentRes.ToString()))
                    {
                        dropDown = true;
                    }
                }

                else
                {
                    scrollPosition = GUI.BeginScrollView(new Rect(1.5f * scrW, 3f * scrH, 3f * scrW, 3.5f * scrH), scrollPosition, viewRect);
                    for (int i = 0; i < resolutions.Length; i++)
                    {
                        if (resolutions[i].width == currentRes.width && resolutions[i].height == currentRes.height)
                        {
                            GUI.Box(new Rect(1.5f * scrW, (3f + i * 0.35f) * scrH, 3f * scrW, 0.35f * scrH), resolutions[i].ToString());
                        }

                        else
                        {
                            if (GUI.Button(new Rect(1.5f * scrW, (3f + i * 0.35f) * scrH, 3f * scrW, 0.35f * scrH), resolutions[i].ToString()))
                            {
                                Screen.SetResolution(resolutions[i].width, resolutions[i].height, fullScreen);
                                dropDown = false;
                            }
                        }
                    }
                    GUI.EndScrollView();
                }
                #endregion

                //THE TOGGLES BELOW ARE WHAT CHANGE THE FULLSCREEN VS WINDOWED

                #region Fullscreen vs Windowed
                //full Screen / windowed toggles
                if (GUI.Toggle(new Rect(5.5f * scrW, 4.5f * scrH, 2 * scrW, 0.5f * scrH), fullScreen, "FullScreen"))
                {
                    Screen.fullScreen = true;//setting fullscreen to true
                    fullScreen = true;//changes the toggle to true allowing the GUI to be filled
                    windowed = false;//changes the toggle to false to show that windowed is unselected
                }

                if (GUI.Toggle(new Rect(5.5f * scrW, 6f * scrH, 2 * scrW, 0.5f * scrH), windowed, "Windowed"))
                {
                    Screen.fullScreen = false; //setting fullscreen to false
                    fullScreen = false;//changes the toggle to false showing that fullscreen is unselected
                    windowed = true;//changes windowed to true allowing the GUI to be filled
                }
                #endregion

                #region Controls
                //Controls
                GUI.Box(new Rect(8.4f * scrW, 0.5f * scrH, 7.125f * scrW, 8f * scrH), "Controls");//left control block
                Event e = Event.current;

                //THE WAY THIS CONTROL SELECTION IS SET UP IS THAT YOU CANT SET A KEY BINDING TO A KEY THAT ALREADY EXISTS
                for (int i = 0; i < keyCodes.Length; i++)
                {
                    GUI.Box(new Rect(8.75f * scrW, (i + 1f) * scrH, 6.25f * scrW, 1f * scrH), keyNames[i]);

                    if (keyCodes[i] != KeyCode.None && canChangeKey)
                    {
                        if (GUI.Button(new Rect(14f * scrW, (1f + i) * scrH, 1f * scrW, 1f * scrH), keyCodes[i].ToString()))
                        {
                            holdingKey = keyCodes[i];
                            keyCodes[i] = KeyCode.None;
                        }
                    }

                    else
                    {
                        GUI.Box(new Rect(14f * scrW, (1f + i) * scrH, 1f * scrW, 1f * scrH), keyCodes[i].ToString());
                    }

                    if (keyCodes[i] == KeyCode.None && e.isKey)
                    {
                        KeyCode[] otherKeys = keyCodes.Where(KeyCode => KeyCode != KeyCode.None).ToArray();
                        for (int n = 0; n < otherKeys.Length; n++)
                        {
                            if (otherKeys[n] == e.keyCode)
                            {
                                dupeKey = true;
                            }
                        }

                        if (dupeKey)
                        {
                            keyCodes[i] = holdingKey;
                            holdingKey = KeyCode.None;
                            dupeKey = false;
                        }

                        else
                        {
                            keyCodes[i] = e.keyCode;
                            holdingKey = KeyCode.None;
                        }
                    }
                }

                if (canChangeKey)
                {
                    if (GUI.Button(new Rect(12.5f * scrW, 8f * scrH, 3 * scrW, 0.5f * scrH), "Back"))//if back is pressed then
                    {
                        options = false;//turn off the options
                    }
                }
                #endregion
            }
        }
    }
}