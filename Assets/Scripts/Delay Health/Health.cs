using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MyNamespace
{
   [AddComponentMenu("Intro PRG/Player/Delay Health")]
    public class Health : MonoBehaviour
    {
        //Player Health Max
        public float maxHealth;
        //Player Health Current
        public float curHealth;
        //Player Health Delay
        public float delayHealth;
        //dropSpeed
        public float dropSpeed = 30f;
        //Reference to:
        //Delay slider
        public Slider delayHealthBar;
        //Health slider
        public Slider healthBar;
        //Delay fill
        public Image delayFill;
        //Current fill
        public Image currentFill;

        void Update()
        {
            //Setting of current health value on slider
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            //if delay health is bigger than that of our current health
            if (delayHealth > curHealth)
            {
                delayHealth -= dropSpeed*Time.deltaTime;
                //Over time, according to our speed, make delay health match the current health value
            }

            else
            {
                delayHealth = curHealth;
            }
            delayHealthBar.value = Mathf.Clamp01(delayHealth / maxHealth);
            curHealthManager();
            delayHealthManager();
        }

        void curHealthManager()
        {
            /*Control the display of the current health fill
            -off and on
            Control the display of the delay health fill
            - off
            - on set dely value to current health
            - on set slider t ocurrent health*/

            if (curHealth <= 0 && currentFill.enabled)
            {
                Debug.Log("Dead");
                currentFill.enabled = false;
            }

            else if (!currentFill.enabled && curHealth > 0)
            {
                Debug.Log("REVIVED");
                currentFill.enabled = true;
            }

            
        }


        void delayHealthManager()
        {
            if (delayHealth <= 0 && delayFill.enabled)
            {
                delayFill.enabled = false;
            }

            else if (!delayFill.enabled && delayHealth > 0)
            {
                delayFill.enabled = true;
            }
        }
        //Protip: Create the health bar using two sliders
        //1. Create slider
        //2. Dupicate slider and make it a child of the first
        //3. Delete the background colour of the child health bar
    }

}
