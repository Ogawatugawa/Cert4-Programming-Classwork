using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogElement : MonoBehaviour
{
    public Quest quest;
    public Text questName;
    public Text questDesc;
    public Text progress;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        questName.text = quest.name;
        questDesc.text = quest.description;

        if (quest.goal.goalType == GoalType.Collect)
        {
            progress.text = quest.goal.currentAmount + "/" + quest.goal.requiredAmount + " " + quest.goal.target + " Collected";
        }

        else
        {
            progress.text = quest.goal.currentAmount + "/" + quest.goal.requiredAmount + " " + quest.goal.target + " Killed";
        }
    }
}
