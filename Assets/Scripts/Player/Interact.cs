using UnityEngine;
using System.Collections;

//this script can be found in the Component section under the option Intro RPG/Player/Interact
namespace Player
{
    [AddComponentMenu("Intro PRG/Player/Interact")]
    public class Interact : MonoBehaviour
    {
        #region Variables
        //We are setting up these variable and the tags in update for week 3,4 and 5
        [Header("Player and Camera connection")]
        //create gameobject variable called player
        public GameObject player;
        #endregion
        #region Start
        void Start()
        {
            //connect our player to the player variable via tag
            player = GameObject.FindGameObjectWithTag("Player");
        }
        #endregion
        #region Update
        void Update()
        {
            //If our interact key is pressed
            //To do this we'll need to create a new axis called 'Interact' in our Input Manager, we'll make the positive buttons for it 'e' and 'joystick button 2'
            if (Input.GetButtonDown("Interact"))

            {
                //create a ray
                Ray interact;

                //this ray is shooting out from the main cameras screen point center of screen
                interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

                //Create a new RaycastHit variable called hitInfo
                //RaycastHit is a structure used to get information back from whatever the raycast hits
                RaycastHit hitInfo;
                
                //if this physics raycast hits something within 10 units
                if (Physics.Raycast(interact, out hitInfo, 10))
                {
                    #region NPC tag

                    //and that hits info is tagged NPC
                    if (hitInfo.collider.CompareTag("NPC"))
                    {
                        //Debug that we hit a NPC
                        Debug.Log("Talking to NPC");
                    }
                    #endregion
                    #region Item
                    //and that hits info is tagged Item
                    if (hitInfo.collider.CompareTag("Item"))
                    {
                        //Debug that we hit an Item
                        Debug.Log("Picked up Item");
                    }
                }

            }
        }
      
        
        #endregion
        #endregion
    }
}







