using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterHeart
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Heart : MonoBehaviour
    {

        private int maxHealth;
        [Header("Heart Slots")]
        public Sprite heart0;
        public Sprite heart1;
        public Sprite heart2;
        public Sprite heart3;
        public Sprite heart4;
        public static SpriteRenderer rend;

        public static Sprite[] hearts = new Sprite[5];
        // Use this for initialization
        void Awake()
        {
            rend = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
           
        }
        // Update is called once per frame
       
    }
}


