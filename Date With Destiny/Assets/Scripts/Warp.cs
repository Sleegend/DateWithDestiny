using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    void OnTriggerEnter2D(Collider2D other) //other is the game object that collides with the trigger
    {
        Debug.Log("Warp");
        other.gameObject.transform.position = warpTarget.position; //warp player to target
        Camera.main.transform.position = warpTarget.position; //move camera to warp position
    }

}
