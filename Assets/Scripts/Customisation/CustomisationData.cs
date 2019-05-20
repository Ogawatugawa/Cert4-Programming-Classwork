using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomisationData
{
    public int skinIndex, eyesIndex, mouthIndex, hairIndex, clothesIndex, armourIndex;
    public string charName;

    public CustomisationData(CustomisationSet custom)
    {
        skinIndex = custom.skinIndex;
        eyesIndex = custom.eyesIndex;
        mouthIndex = custom.mouthIndex;
        hairIndex = custom.hairIndex;
        clothesIndex = custom.clothesIndex;
        armourIndex = custom.armourIndex;

        charName = custom.charName;
    }

}
