using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterHeart
{
    [AddComponentMenu("Intro PRG/Player/Health")]
    public class OldHealth : MonoBehaviour
        {
        [Header("Player Stats")]
        public float maxHealth = 12f;
        public float curHealth = 12f;
        [Header("Heart Slots")]   // HOMEWORK GOES HERE
        //Canvas Image heartSlots array
        public Image[] heartSlots = new Image[3];
        //Sprite hearts array
        public Sprite[] hearts = new Sprite[5];
        //private percent healthPerSection
        private float healthPerSection;
        #region Start
        void Start()
        {
            UpdateHearts();
            
        }
           // Run UpdateHearts
        #endregion
	    #region Update 
        void Update()
        {
            int i = 0;
        //index variable starting at 0 for slot checks
            foreach (Image Slot in heartSlots)
            //foreach Image slot in heartSlots
            {
                if (curHealth >= healthPerSection*4 + healthPerSection*4*i)
                //if curHealth is greater or equal to full for this slot amount
                {
                    heartSlots[i].sprite = hearts[0];
                    //Set heart to 4/4
                }   
                else if (curHealth >= healthPerSection*3 + healthPerSection*4*i)
                {
                    heartSlots[i].sprite = hearts[1];  
                }
                //else if curHealth is greater or equal to 3/4 for this slot amount
                    //Set Heart to 3/4
                 else if (curHealth >= healthPerSection*2 + healthPerSection*4*i)
                {
                    heartSlots[i].sprite = hearts[2];
                }
                //else if curHealth is greater or equal to 2/4 for this slot amount
                    //Set Heart to 2/4
                 else if (curHealth >= healthPerSection + healthPerSection*4*i)
                {
                    heartSlots[i].sprite = hearts[3];
                }
                //else if curHealth is greater or equal to 1/4 for this slot amount
                    //Set Heart to 1/4
                else
                {
                    heartSlots[i].sprite = hearts[4];
                }
                //else
                //we are empty
            i++;
            }
        
            
             
            //after checking this slot increase slot index
        }
	    #endregion
        #region UpdateHearts
        void UpdateHearts()
        {
            healthPerSection = maxHealth/(heartSlots.Length*4);
        }
        //calculate the health points per heart section
        #endregion
    }
}
