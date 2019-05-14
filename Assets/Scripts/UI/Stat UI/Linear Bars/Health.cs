using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearHealthBar
{

    [AddComponentMenu("Intro PRG/Player/Linear Bars/Health")]
	public class Health : MonoBehaviour 
	{
		[Header("Player Health")]
		private float maxHealth;
		private float curHealth;
		[Header("UI Reference")]
		public Slider healthBar;
		public Image sliderFill;
        public PlayerManager player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }

        void Update()
		{
            maxHealth = player.maxHealth;
            curHealth = player.currentHealth;
            healthBar.value = Mathf.Clamp01(curHealth/maxHealth);
			HealthManager();
		}

		void HealthManager()
		{
			if(curHealth <= 0 && sliderFill.enabled)
			{
				Debug.Log("Dead");
				sliderFill.enabled = false;
			}
			else if(!sliderFill.enabled && curHealth > 0)
			{
				Debug.Log("REVIVED");
				sliderFill.enabled = true;
			}
		}
	}
}
