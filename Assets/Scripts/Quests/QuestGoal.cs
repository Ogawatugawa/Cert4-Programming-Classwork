// Serializable allows us to turn data into a transmittable and readable stream of bytes 
[System.Serializable]
public class QuestGoal
{
    // Goal type
    public GoalType goalType;
    // Required amount
    public int requiredAmount;
    // Current amount
    public int currentAmount;
    // Is reached
    // You can make it so that the bool ticks on when a condition is fulfilled by running it as a function with 'return'
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    // Enemy killed
    public void Killed()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }
    }

    // Object collected
    public void Collected()
    {
        if (goalType == GoalType.Collect)
        {
            currentAmount++;
        }
    }
}

public enum GoalType { Kill, Collect }
