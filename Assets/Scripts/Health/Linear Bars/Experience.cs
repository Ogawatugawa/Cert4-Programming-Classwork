using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearEXPBar
{

    [AddComponentMenu("Intro PRG/Player/Linear Bars/Experience")]
    public class Experience : MonoBehaviour
    {
        [Header("Player Health")]
        private float maxExp;
        private float curExp;
        [Header("UI Reference")]
        public Slider expBar;
        public Image sliderFill;
        public PlayerManager player;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }
        void Update()
        {
            maxExp = player.maxExperience;
            curExp = player.currentExperience;
            expBar.value = Mathf.Clamp01(curExp / maxExp);
            HealthManager();
        }

        void HealthManager()
        {
            if (curExp <= 0 && sliderFill.enabled)
            {
                sliderFill.enabled = false;
            }
            else if (!sliderFill.enabled && curExp > 0)
            {
                sliderFill.enabled = true;
            }
        }
    }
}