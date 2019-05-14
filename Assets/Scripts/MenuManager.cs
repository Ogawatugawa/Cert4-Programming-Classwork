using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public GameObject pausePanel;
    public GameObject resumeBtn, saveBtn, loadBtn, exitBtn;

    // Use this for initialization

    public void PauseGame(bool IsPaused)
    {
        if (IsPaused)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Movement.canMove = false;
            pausePanel.SetActive(true);
        }

        else
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
            pausePanel.SetActive(false);
        }
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void Start()
    {
        PauseGame(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pausePanel.activeSelf && DialogueManager.DialogueOn == false)
        {
            PauseGame(true);
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf)
        {
            PauseGame(false);
        }
    }
}
