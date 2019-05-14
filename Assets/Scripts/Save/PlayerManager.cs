using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Name")]
    public new string name;
    [Header("Player Level")]
    public int level;
    [Header("Player Stats")]
    public float currentHealth;
    public float maxHealth, currentMana, maxMana, currentStamina, maxStamina, currentExperience, maxExperience;
    [Header("Player Inventory")]
    public float playerGold;
    [Header("Player Checkpoint")]
    public CheckPoint checkPoint;
    public float xPos, yPos, zPos;

    private void Start()
    {
        checkPoint = GetComponent<CheckPoint>();
    }

    private void Update()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += 10 * Time.deltaTime;
        }
    }

    public void SavePlayer()
    {
        //xPos = checkPoint.curCheckPoint.x;
        //yPos = checkPoint.curCheckPoint.y;
        //zPos = checkPoint.curCheckPoint.z;
        xPos = gameObject.transform.position.x;
        yPos = gameObject.transform.position.y;
        zPos = gameObject.transform.position.z;
        Save.SavePlayerdata(this);
    }

    public void LoadPlayer()
    {
        DataToSave data = Save.LoadPlayerdata();
        level = data.level;
        name = data.playerName;
        currentHealth = data.currentHealth;
        maxHealth = data.maxHealth;
        currentMana = data.currentMana;
        currentStamina = data.currentStamina;
        maxExperience = data.maxExperience;
        currentExperience = data.currentExperience;
        maxExperience = data.maxExperience;
        xPos = data.xPos;
        yPos = data.yPos;
        zPos = data.zPos;
        transform.position = new Vector3(xPos, yPos, zPos);
    }

    public void TakeStamina(float staminaCost)
    {
        currentStamina -= staminaCost;
    }
}
