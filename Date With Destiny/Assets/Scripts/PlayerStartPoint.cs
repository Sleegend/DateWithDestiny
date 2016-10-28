using UnityEngine;
using System.Collections;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerMovement thePlayer;
    private CameraFollow theCamera;

    public string pointName; //used for warp scene
	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerMovement>(); //find object with PlayerMovement script attached to it

        if(thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position; //make player position the same as the start point in this scene

            theCamera = FindObjectOfType<CameraFollow>();
            //want camera position of x and y to be the starting point, but not z since it'll b zoomed right at it and become black screen
            //want the camera position of z from the camera itself instead
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
        
    }
	
	// Update is called once per frame
	void Update () {


    }
}
