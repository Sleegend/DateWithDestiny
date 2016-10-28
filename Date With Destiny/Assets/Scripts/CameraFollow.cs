using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public float lerpSpeed = 0.1f;
    public Transform target; //transform stores position, scale and rotation data of an object
    Camera mycam;

    private static bool cameraExists;
	// Use this for initialization
	void Start () {
        mycam = GetComponent<Camera>();

        if (!cameraExists)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

	
	}
	
	// Update is called once per frame
	void Update () {
        //scale will remain even if we resize window
        //mycam.orthographicSize = (Screen.height / 100f) / 2f;// orthographic size is the camera size, 2f is the scale
        mycam.orthographicSize = 1.6f;// orthographic size is the camera size, 2f is the scale

        if (target)
        {
            //new Vector3(0,0,-10) used to camera isnt in same position as player (not visible)
            transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed) + new Vector3(0,0,-10);  //transform -> position of camera
                                                //from              to              how fast
            
        }
	}
}
