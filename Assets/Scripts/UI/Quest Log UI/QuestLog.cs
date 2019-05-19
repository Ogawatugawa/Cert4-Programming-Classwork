using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public GameObject logPanel;
    public GameObject elementPrefab;
    public PlayerQuest playerQuest;
    public GameObject contentWindow;
    public List<Quest> quests = new List<Quest>();
    // Start is called before the first frame update
    void Start()
    {
        logPanel.SetActive(false);
        playerQuest = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerQuest>();
        UpdateLog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            logPanel.SetActive(true);
            UpdateLog();
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            logPanel.SetActive(false);
        }

    }

    GameObject GenerateElement(Vector2 pos)
    {
        GameObject clone = Instantiate(elementPrefab, contentWindow.transform);
        clone.transform.position = pos;
        return clone;
    }

    void UpdateLog()
    {
        List<Quest> quests = playerQuest.quests;
        int i = 0;
        foreach (Quest quest in quests)
        {
            Vector2 pos = new Vector2(-20, (3 + i * 100));
            GameObject qlElement = GenerateElement(pos);
            LogElement element = qlElement.GetComponent<LogElement>();
            element.quest = quests[i];
            i++;
        }

        RectTransform rect = contentWindow.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2();

    }
}