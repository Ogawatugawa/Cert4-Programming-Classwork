using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Character Set Up 
//Character Movement
//This script requires the component Character controller
[RequireComponent(typeof(CharacterController))]
//This makes the script pull the Character Controller component onto the object along with this script
[AddComponentMenu("IntroPRG/RPG/Player/Movement")]
//This creates a new section in the Add Component Menu called "IntroPRG", with the subsection inside called "RPG", and names the script Player Movement. Each backslash denotes a new subsection.
public class Movement : MonoBehaviour
{
    //writing #region creates a collapsible section of code, for tidiness
    #region Variables
    [Header("Character Move Direction")]
    //Creates a section called Character Move Direction in the Inspector under the script section
    //This will chuck up an error if you don't put variables under it
    public Vector3 moveDirection;
    //public means that the variable can be viewed and changed in the Inspector 
    //vector3 called moveDirection <-- Variables! Hence camelCase name
    //we will use this to apply movement in worldspace
    //private CharacterController (https://docs.unity3d.com/ScriptReference/CharacterController.html) charC
    private CharacterController _charC;
    //private means it can't be seen or changed in the Inspector

    [Header("Character Variables")]
    //public float variables jumpSpeed, speed, gravity
    public float jumpSpeed;
    public float speed;
	
	//public float sprintSpeed;
    
	public float gravity;
    //You can also write this as public float jumpSpeed, speed, gravity; but it'll screw up the formatting
    //fix this by writing is as:
    //public float jumpSeed;
    //public float speed, gravity;

    #endregion
    #region Start
    private void Start()
    {

        //charc is on this game object we need to get the character controller that is attached to it

        _charC = this.GetComponent<CharacterController>();
        //You don't need to write 'this', but it's useful right now to remind you that the script is pulling the component CharacterController that is attached to itself. It does this by default.
        //Sometimes you'll need to pull it from elsewhere, and you'll have to write the location in those cases

    }
    #endregion
    #region Update
    private void Update()
    {

        //if our character is grounded
        if (_charC.isGrounded) //we are able to move in game scene meaning
        {
            //moveDir has the value of Input.Get Axis.. Horizontal, 0, Vertical
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //This line tells the script to do something to the Move Direction variables because we've pressed a button

            //moveDir is transformed in the direction of our moveDir
            moveDirection = transform.TransformDirection(moveDirection);
            //transform.TransformDirection tells the script to move according to the player's directions, rather than the orientation of the world's directions
            //This line tells the script whether it'll move according to local or global directions

            //our moveDir is then multiplied by our speed
            moveDirection *= speed;
            //This line tells the script how fast the movement will be

            //if the input button for jump is pressed then

            if (Input.GetButton("Jump"))
            //our moveDir.y is equal to our jump speed
                {
                moveDirection.y = jumpSpeed;
                }

			/*if (Input.GetButtonDown("Sprint"))
				{
				speed = sprintSpeed;
				Debug.Log ("Sprinting");
				}
			*/
        }
        //regardless of if we are grounded or not the players moveDir.y is always affected by gravity timesed by time.deltaTime to normalize it
        moveDirection.y -= gravity * Time.deltaTime;
        //Rigidbody applies gravity to objects, but we can't put player physics and collision on the player object as well as rigidbody as they will both start freaking out

        //we then tell the character Controller that it is moving in a direction timesed Time.deltaTime
        _charC.Move(moveDirection * Time.deltaTime);
        //using deltaTime makes the speed of movement act according to the frame time rather than by real time, keeping it consistent regardless of the rendering speed
    }
    #endregion
}
//Input Manager(https://docs.unity3d.com/Manual/class-InputManager.html)
//Input(https://docs.unity3d.com/ScriptReference/Input.html)










