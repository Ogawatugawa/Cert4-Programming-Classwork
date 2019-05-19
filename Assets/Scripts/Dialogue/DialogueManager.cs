using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    public Dialogue dlg;

    [Header("Dialogue UI Elements")]
    public GameObject dlgPanel;
    public GameObject nextBtn, exitBtn;
    public Text text;

    [Header("Dialogue Variables")]
    public int approval;
    public int index;
    public int newQuestIndex, acceptedQuestIndex;
    public static bool DialogueOn = false;
    public string[] dmText;
    public string[][] dmArray;

    [Header("Quest Elements")]
    public GameObject questPanel;
    public GameObject acceptBtn, declineBtn, completeBtn, questExitBtn;
    public QuestGiver questGiver;
    #endregion

    #region Button Functions
    #region NextDialogue
    public void NextDialogue()
    {
        print("Next Button Pressed");
        index++;
    }
    #endregion
    #region AcceptDialogue
    public void AcceptDialogue()
    {
        if (questGiver && questGiver.quest.state == QuestState.New)
        {
            if (approval == 0)
            {
                approval++;
            }
            questGiver.AcceptQuest();
            CheckApproval();
            index += 2;
        }
    }
    #endregion
    #region DeclineDialogue
    public void DeclineDialogue()
    {
        if (approval > 0 && questGiver.quest.state == QuestState.New)
        {
            approval--;
        }
        CheckApproval();
        index = dmText.Length - 1;
    }
    #endregion
    #region ClaimQuest
    public void ClaimQuestDialogue()
    {
        approval = dmArray.Length - 1;
        questGiver.ClaimQuest();
        CheckApproval();
        index = dmText.Length - 1;
    }
    #endregion
    #region DialogueOff
    public void DialogueOff()
    {
        if (dlg)
        {
            index = 0;

            DialogueOn = false;
            questGiver = null;
            dlg.approval = approval;

            questPanel.SetActive(false);
            dlgPanel.SetActive(false);

            if (Time.timeScale > 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Movement.canMove = true;
            }
        }
    }
    #endregion
    #endregion

    #region Check Approval
    public void CheckApproval()
    {
        switch (approval)
        {
            case 0:
                dmText = dmArray[0];
                break;
            case 1:
                dmText = dmArray[1];
                break;
            case 2:
                dmText = dmArray[2];
                break;
            default:
                break;
        }
    }
    #endregion

    #region Initialise Dialogue
    public void InitiliaseDialogue()
    {
        Movement.canMove = false;

        dmArray = new string[dlg.dialogueArray.Length][];
        dmArray = dlg.dialogueArray;
        approval = dlg.approval;
        dmText = new string[dmArray[approval].Length];
        newQuestIndex = dlg.newQuestIndex;
        acceptedQuestIndex = dlg.acceptedQuestIndex;

        if (questGiver)
        {
            if (questGiver.quest.state == QuestState.Accepted || questGiver.quest.state == QuestState.Completed)
            {
                print("Quest Giver's quest already accepted");
                index = acceptedQuestIndex;
            }
        }
        CheckApproval();

        DialogueOn = true;
    }
    #endregion

    #region Start
    public void Start()
    {
        dlgPanel = GameObject.Find("Dialogue Panel");
        nextBtn = GameObject.Find("Next Button");
        exitBtn = GameObject.Find("Dialogue Exit Button");
        text = GameObject.Find("Dialogue Text").GetComponent<Text>();

        questPanel = GameObject.Find("Quest Panel");
        acceptBtn = GameObject.Find("Accept Button");
        declineBtn = GameObject.Find("Decline Button");
        completeBtn = GameObject.Find("Complete Button");
        questExitBtn = GameObject.Find("Quest Exit Button");

        dlgPanel.SetActive(false);
        questPanel.SetActive(false);
    }
    #endregion

    #region Update
    public void Update()
    {
        if (DialogueOn)
        {
            dlgPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            newQuestIndex = dlg.newQuestIndex;
            text.text = dmText[index];

            Quest quest = questGiver.quest;

            if ((index < dmText.Length - 1 && index != newQuestIndex && index != acceptedQuestIndex) || (index < dmText.Length - 1 && quest.state == QuestState.Claimed))
            {
                nextBtn.SetActive(true);
                exitBtn.SetActive(false);
                questPanel.SetActive(false);
            }

            else if (index == newQuestIndex && quest.state != QuestState.Claimed)
            {
                nextBtn.SetActive(false);
                exitBtn.SetActive(false);
                questGiver.OpenQuestWindow();

                if (quest.state == QuestState.New)
                {
                    completeBtn.SetActive(false);
                    questExitBtn.SetActive(false);
                    acceptBtn.SetActive(true);
                    declineBtn.SetActive(true);
                }

                if (quest.state == QuestState.Accepted || quest.state == QuestState.Completed)
                {
                    index = acceptedQuestIndex;
                }
            }

            else if (index == acceptedQuestIndex && quest.state != QuestState.Claimed)
            {
                nextBtn.SetActive(false);
                exitBtn.SetActive(false);
                questGiver.OpenQuestWindow();

                if (quest.state == QuestState.Completed)
                {
                    completeBtn.SetActive(true);
                    questExitBtn.SetActive(true);
                    acceptBtn.SetActive(false);
                    declineBtn.SetActive(false);
                }

                else
                {
                    completeBtn.SetActive(false);
                    questExitBtn.SetActive(true);
                    acceptBtn.SetActive(false);
                    declineBtn.SetActive(false);
                }
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
    #endregion
}