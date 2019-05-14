using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearStaminaBar
{

    [AddComponentMenu("Intro PRG/Player/Linear Bars/Stamina")]
    public class Stamina : MonoBehaviour
    {
        [Header("Player Health")]
        private float maxStam;
        private float curStam;
        [Header("UI Reference")]
        public Slider stamBar;
        public Image sliderFill;
        public PlayerManager player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }
        void Update()
        {
            maxStam = player.maxStamina;
            curStam = player.currentStamina;
            stamBar.value = Mathf.Clamp01(curStam / maxStam);
            StaminaManager();
        }

        void StaminaManager()
        {
            if (curStam <= 0 && sliderFill.enabled)
            {
                Debug.Log("Out of stamina");
                sliderFill.enabled = false;
            }
            else if (!sliderFill.enabled && curStam > 0)
            {
                sliderFill.enabled = true;
            }
        }
    }
}