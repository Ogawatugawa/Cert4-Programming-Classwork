using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour {

    public float maxHP = 100f;
    public float curHP = 100f;
    public Canvas myCanvas;
    public Slider mySlider;
	// Use this for initialization
	void Start () {
        myCanvas = this.transform.Find("Canvas").GetComponent<Canvas>();
        mySlider = myCanvas.transform.Find("Enemy Health Bar").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        mySlider.value = Mathf.Clamp01(curHP / maxHP);
        myCanvas.transform.LookAt(Camera.main.transform);
	}
}
