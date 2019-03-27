using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int level;
    public new string name;
    public float currentHealth, maxHealth, currentMana, maxMana, currentStamina, maxStamina, currentExperience, maxExperience;
    public CheckPoint checkPoint;
    public float xPos, yPos, zPos;

    private void Start()
    {
        checkPoint = GetComponent<CheckPoint>();
    }

    public void SavePlayer()
    {
        /*xPos = checkPoint.curCheckPoint.x;
        yPos = checkPoint.curCheckPoint.y;
        zPos = checkPoint.curCheckPoint.z;*/
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
}
