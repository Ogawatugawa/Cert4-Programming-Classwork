// Serializable allows us to turn data into a transmittable and readable stream of bytes 
[System.Serializable]
public class Quest
{
    // Quest State
    public QuestState state = QuestState.New;
    // Name
    public string name;
    // Description
    public string description;
    // Experience reward
    public float expReward;
    // Gold reward
    public float goldReward;
    // Item reward


    // Goal
    public QuestGoal goal;

    // SourceID (Where/what triggers the quest? This needs a database to work)
    // QuestID (If we have a quest DB, which one of those quests is this one?)
    public int questID;
    // QuestChainID (If we have a quest DB, this could let us link this quest to be part of a series of quests)

    // Complete
    public void Complete ()
    {
        state = QuestState.Completed;
    }
}
public enum QuestState { New, Accepted, Failed, Completed, Claimed }