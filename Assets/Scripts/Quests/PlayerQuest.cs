// FYI, arrays use System.Collections
using System.Collections;
// Donut forget, Lists and Dictionaries need System.Collections.Generic
using System.Collections.Generic;
using UnityEngine;

public class PlayerQuest : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void Update()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (quests[i].goal.IsReached() && quests[i].state != QuestState.Claimed)
            {
                quests[i].state = QuestState.Completed;
            }
        }
    }
}
