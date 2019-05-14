using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string nPCName;

    [Header("NPC Approval")]
    public int approval = 1;

    [Header("Dialogue/Quest Indices")]
    public int index;
    public int newQuestIndex, acceptedQuestIndex;

    [Header("Dialogue Arrays")]
    public string[] meanDialogue;
    public string[] neutralDialogue;
    public string[] niceDialogue;
    public string[][] dialogueArray = new string[3][];

    private void Awake()
    {
        dialogueArray[0] = meanDialogue;
        dialogueArray[1] = neutralDialogue;
        dialogueArray[2] = niceDialogue;
    }
}
