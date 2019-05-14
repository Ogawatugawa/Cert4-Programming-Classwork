using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearManaBar
{

    [AddComponentMenu("Intro PRG/Player/Linear Bars/Mana")]
    public class Mana : MonoBehaviour
    {
        [Header("Player Health")]
        private float maxMana;
        private float curMana;
        [Header("UI Reference")]
        public Slider manaBar;
        public Image sliderFill;
        public PlayerManager player;
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        }
        void Update()
        {
            maxMana = player.maxMana;
            curMana = player.currentMana;
            manaBar.value = Mathf.Clamp01(curMana / maxMana);
            ManaManager();
        }

        void ManaManager()
        {
            if (curMana <= 0 && sliderFill.enabled)
            {
                Debug.Log("Out of mana");
                sliderFill.enabled = false;
            }
            else if (!sliderFill.enabled && curMana > 0)
            {
                sliderFill.enabled = true;
            }
        }
    }
}