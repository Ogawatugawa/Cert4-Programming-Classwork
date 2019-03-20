using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int level;
    public string playerName;
    public float currentHealth, maxHealth, currentMana, maxMana, currentStamina, maxStamina, currentExperience, maxExperience;
    public float xPos, yPos, zPos;

    public DataToSave(PlayerManager player)
    {
        level = player.level;
        playerName = player.name;
        currentHealth = player.currentHealth;
        maxHealth = player.maxHealth;
        currentMana = player.currentMana;
        maxMana = player.maxExperience;
        currentStamina = player.currentStamina;
        maxStamina = player.maxStamina;
        currentExperience = player.currentExperience;
        maxExperience = player.maxExperience;
        xPos = player.xPos;
        yPos = player.yPos;
        zPos = player.zPos;
    }

}
