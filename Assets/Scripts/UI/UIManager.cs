using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text goldText;
    public Text interactText;
    public PlayerManager player;
    // Start is called before the first frame update
    void Start()
    {
        interactText = GameObject.Find("Interactable Text").GetComponent<Text>();
        goldText = GameObject.Find("Gold Text").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        interactText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + player.playerGold.ToString();

        Ray tagRay;
        tagRay = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Physics.Raycast(tagRay, out hitInfo, 2))
        {
            Dialogue dialogue = hitInfo.collider.GetComponent<Dialogue>();
            if (dialogue && Time.timeScale > 0 && !DialogueManager.DialogueOn)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = dialogue.nPCName; 
            }

            else
            {
                interactText.gameObject.SetActive(false);
            }
        }

        else
        {
            interactText.gameObject.SetActive(false);
        }
    }
}
