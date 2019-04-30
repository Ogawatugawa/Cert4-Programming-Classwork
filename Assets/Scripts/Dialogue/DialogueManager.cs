using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public static DialogueManager Instance;
   
    [Header("Dialogue Elements")]
    public GameObject dlgPanel;
    public GameObject nextBtn, exitBtn;
    public string[] dlgText;
    public Text text;
    public int index;
    public int optionsIndex;
    public Dialogue2 dlg;
    public bool DialogueOn = false;
    
    [Header("Quest Elements")]
    public GameObject questPanel;
    public GameObject acceptBtn, declineBtn;
    //public Text questNameText;
    //public Text questDescText, questExpReward, questGoldReward;
    public QuestGiver questGiver;

    [Header("Pause Menu")]
    public GameObject pausePanel;

    public void NextDialogue()
    {
        index++;
    }

    public void ExitDialogue()
    {
        index = 0;
        DialogueOn = false;
    }

    public void AcceptDialogue()
    {
        if (questGiver)
        {
            questGiver.AcceptQuest();
            index++;
        }
    }

    public void DeclineDialogue()
    {
        index = dlgText.Length - 1;
    }

    public void DialogueOff()
    {
        DialogueOn = false;
        questGiver = null;
        questPanel.SetActive(false);
        dlgPanel.SetActive(false);
        if (Time.timeScale > 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Movement.canMove = true;
        }
    }

    public void Update()
    {
        if (DialogueOn)
        {
            dlgPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            optionsIndex = dlg.optionsIndex;
            text.text = dlgText[index];

            if (index < dlgText.Length - 1 && index != optionsIndex)
            {
                nextBtn.SetActive(true);
                exitBtn.SetActive(false);
                questPanel.SetActive(false);
            }

            else if (index == optionsIndex)
            {
                nextBtn.SetActive(false);
                exitBtn.SetActive(false);
                questGiver.OpenQuestWindow();
            }

            else
            {
                nextBtn.SetActive(false);
                exitBtn.SetActive(true);
                questPanel.SetActive(false);
            }
        }

        else
        {
            DialogueOff();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DialogueOff();
        }
    }
}
