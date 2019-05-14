using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCodeDialogue : MonoBehaviour {
    #region Variables
    // Is dialogue visible?
    public bool showDialogue;
    // Screen measurments we'll use to size and place things based on aspect ratio
    public Vector2 scr;
    // Array of dialogue text
    public string[] dialogueText;
    // Int for indexing dialogue from the array
    public int index, optionsIndex;


    #endregion
    void OnGUI ()
    {
        if (showDialogue)
        {   // If scr is not set to even units re: aspect ratio
            if (scr.x != Screen.width/16 || scr.y != Screen.height/9)
            {
                scr.x = Screen.width / 16;
                scr.y = Screen.height / 9;
            }
            //          Rect([x co-ordinates of starting point, y co-ordinates of starting point],[size on the x, size on the y])
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GUI.Box(new Rect(0,6*scr.y,Screen.width, 3*scr.y), dialogueText[index]);
            if (index < dialogueText.Length -1 && index != optionsIndex)
            {

                // Buttons have to be if statements in hard coded GUI
                if (GUI.Button(new Rect(13.5f*scr.x,5*scr.y,2*scr.x,scr.y), "Next"))
                {
                    index++;
                }
            }

            else if (index == optionsIndex)
            {
                if (GUI.Button(new Rect(5.5f * scr.x, 5 * scr.y, 2 * scr.x, scr.y), "Accept"))
                {
                    index++;
                }

                if (GUI.Button(new Rect(8.5f * scr.x, 5 * scr.y, 2 * scr.x, scr.y), "Decline"))
                {
                    index = dialogueText.Length - 1;
                }
            }

            else
            {
                if (GUI.Button(new Rect(13.5f * scr.x, 5 * scr.y, 2 * scr.x, scr.y), "Exit"))
                {
                    index = 0;
                    showDialogue = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    Movement.canMove = true;
                }
            }
            
        }
    }
}
