using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardCode : MonoBehaviour {
    [Range(0,100)]
    public float maxHP = 100, curHP = 100;
    public Vector2 scr;
    public Vector2 size;

    private void OnGUI()
    {
        if (scr.x != Screen.width/16)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }

        for (int x = 0; x < 17; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GUI.Box(new Rect(scr.x * x, scr.y * y, scr.x * size.x, scr.y * size.y), "");
            }
        }

        GUI.Box(new Rect(scr.x, scr.y * 0.25f, scr.x * 3, scr.y * 0.75f), "");
        GUI.Box(new Rect(scr.x, scr.y * 0.25f, (scr.x * 3) * curHP/maxHP, scr.y * 0.75f), "");


        //GUI.Box(new Rect(0, 0, 100, 100), "");
    }
}
