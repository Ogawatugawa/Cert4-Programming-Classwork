using UnityEngine;
using System.Collections;
[AddComponentMenu("IntroPRG/RPG/Player/Mouse Look")]
//this script can be found in the Component section under the option Intro PRG/Mouse Look

public class MouseLook : MonoBehaviour
{
    //Before you write this section please scroll to the bottom of the page
    #region Variables
    [Header("Rotational Axis")]
    public RotationalAxis axis = RotationalAxis.MouseX;

    //create a public link to the rotational axis called axis and set a defualt axis

    [Header("Sensitivity")]
    [Range(1, 20)]
    public float sensitivityX = 15;
    [Range(1, 20)]
    public float sensitivityY = 15;
    //public floats for our x and y sensitivity

    [Header("Y Rotation Clamp")]
    public float minY = -60;
    public float maxY = 60;
    //max and min Y rotation


    //we will have to invert our mouse position later to calculate our mouse look correctly

    private float rotationY = 0;
    //float for rotation Y
    #endregion
    #region Start
    void Start()
    {
        if (GetComponent<Rigidbody>())
        //This line of code checks if Rigidbody is attached and the following will only run if that is the case
        {
            GetComponent<Rigidbody>().freezeRotation = true;
            //This will tick its Freeze Rotation values to active
        }

    }

    #endregion
    #region Update
    private void Update()
    {
        if (Movement.canMove)
        {
            #region Mouse X and Y
            if (axis == RotationalAxis.Mousexandy)
            //if our axis is set to Mouse X and Y
            {
                float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
                //Declaring rotationX here denotes that this variable will only be accessible here in this function 

                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                //float rotation x is equal to our y axis plus the mouse input on the Mouse X times our x sensitivity
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                //our rotation Y is plus equals  our mouse input for Mouse Y times Y sensitivity
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
                //transform our local position to the new vector3 rotaion - y rotation on the x axis and x rotation on the y axis
                //We make the y rotation negative since the 0,0 point on the screen is in the top left corner

            }





            #endregion
            #region Mouse X
            else if (axis == RotationalAxis.MouseX)
            //else if we are rotating on the X
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
                //transform the rotation on our game objects Y by our Mouse input Mouse X times X sensitivity
                //x                y                          z
            }




            #endregion
            #region Mouse Y

            else
            //else we are only rotation on the Y
            {
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                //our rotation Y is plus equals our mouse input for Mouse Y times Y sensitivity
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                //the rotation Y is clamped using Mathf and we are clamping the y rotation to the Y min and Y max
                transform.localEulerAngles = new Vector3(-rotationY, 0, 0);
                //transform our local position to the nex vector3 rotation - y rotation on the x axis and local euler angle Y on the y axis
            }


            #endregion 
        }
    }


    #endregion
}
#region RotationalAxis
/*
enums are what we call state value variables 
they are comma separated lists of identifiers
we can use them to create Type or Category variables
meaning each heading of the list is a type or category element that this can be
eg weapons in an inventory are a type of inventory item
if the item is a weapon we can equipt it
if it is a consumable we can drink it
it runs different code depending on what that objects enum is set to
you can also have subtypes within those types
eg weapons are an inventory category or type
we can then have ranged, melee weapons
or daggers, short swords, long swords, mace, axe, great axe, war axe and so on
each Type or Category holds different infomation the game needs like 
what animation plays, where the hands sit on the weapon, how many hands sit on the weapon and so on
*/
//Create a public enum called RotationalAxis

//Creating an enum out side the script and making it public means it can be asessed anywhere in any script with out reference
#endregion
public enum RotationalAxis
{
    Mousexandy,
    MouseX,
    MouseY
}











