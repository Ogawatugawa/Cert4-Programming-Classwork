using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class QuestUI
{
    public PlayerQuest player;
    public GameObject questWindow;

    public Text nameText;
    public Text descriptionText, expText, goldText;
}

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestUI uI;

    public void OpenQuestWindow ()
    {
        uI.questWindow.SetActive(true);
        uI.nameText.text = quest.name;
        uI.descriptionText.text = quest.description;
        uI.expText.text = quest.expReward.ToString() + " EXP";
        uI.goldText.text = quest.goldReward.ToString() + " Gold";
    }

    public void AcceptQuest ()
    {
        uI.questWindow.SetActive(false);
        if (quest.state == QuestState.New)
        {
            quest.state = QuestState.Accepted;
            uI.player.quests.Add(quest);
        }
    }

    public void ClaimQuest()
    {
        PlayerManager player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
 
        if (quest.state == QuestState.Completed)
        {
            quest.state = QuestState.Claimed;
            player.playerGold += quest.goldReward;
            player.currentExperience += quest.expReward;
        }

        uI.questWindow.SetActive(false);

    }

    public void Awake()
    {
        uI.player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuest>();
        uI.questWindow = GameObject.Find("Quest Panel");
        uI.nameText = GameObject.Find("Quest Name").GetComponent<Text>();
        uI.descriptionText = GameObject.Find("Quest Desc").GetComponent<Text>();
        uI.expText = GameObject.Find("Quest Exp Reward").GetComponent<Text>();
        uI.goldText = GameObject.Find("Quest Gold Reward").GetComponent<Text>();
    }
}
