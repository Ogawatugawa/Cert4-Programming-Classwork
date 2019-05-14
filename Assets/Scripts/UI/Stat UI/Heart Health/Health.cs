using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

namespace QuarterHeart
{
    [AddComponentMenu("Intro PRG/Player/Health")]
    public class Health : MonoBehaviour
    {
        public static Health Instance = null;
        [Header("Player Stats")]
        public int maxHealth = 12;
        public int curHealth = 12;
        [Header("Heart Slots")]   // HOMEWORK GOES HERE
        //Canvas Image heartSlots array
        //public Image[] heartSlots;
        //Sprite hearts array
        public Sprite[] hearts = new Sprite[5];
        //private percent healthPerSection
        private float healthPerSection;
        public Image heartImagePrefab;
        public Image[] heartSlots;
        private int width;
        private float spacing = 35f;

        public Canvas canvas;
        

        #region Start
        void Start()
        {
            width = maxHealth / 4;
            heartSlots = new Image[width];
            GenerateHearts();
            // Run UpdateHearts
            UpdateHearts();
        }
        #endregion
        #region Update 
        void Update()
        {
            //index variable starting at 0 for slot checks
            int i = 0;
            foreach (Image Slot in heartSlots)
            //foreach Image slot in heartSlots
            {
                if (curHealth >= healthPerSection * 4 + healthPerSection * 4 * i)
                //if curHealth is greater or equal to full for this slot amount
                {
                    heartSlots[i].sprite = hearts[0];
                    //Set heart to 4/4
                }
                else if (curHealth >= healthPerSection * 3 + healthPerSection * 4 * i)
                {
                    heartSlots[i].sprite = hearts[1];
                }
                //else if curHealth is greater or equal to 3/4 for this slot amount
                //Set Heart to 3/4
                else if (curHealth >= healthPerSection * 2 + healthPerSection * 4 * i)
                {
                    heartSlots[i].sprite = hearts[2];
                }
                //else if curHealth is greater or equal to 2/4 for this slot amount
                //Set Heart to 2/4
                else if (curHealth >= healthPerSection + healthPerSection * 4 * i)
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

                //after checking this slot increase slot index
                i++;
            }

            
        }

        Image SpawnHeart(Vector2 pos)
        {

            Image clone = Instantiate(heartImagePrefab);

            clone.transform.position = pos;

            return clone;

        }



        void GenerateHearts()
        {
            
                for (int i = 0; i < width; i++)
                {
                    Vector2 pos = new Vector2(.75f + i, 465);
                    pos.x *= spacing;
                    Image heart = SpawnHeart(pos);
                    heart.transform.SetParent(transform);
                    heartSlots[i] = heart;
                }
            
        }
        #endregion
        #region UpdateHearts
        void UpdateHearts()
        {
            healthPerSection = maxHealth / (heartSlots.Length * 4);
        }
        //calculate the health points per heart section
        #endregion
    }
}
