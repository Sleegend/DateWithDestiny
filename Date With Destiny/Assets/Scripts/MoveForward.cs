using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

    public float maxSpeed = 5f; //speed of projectile
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position; //current position the projectile is facing
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        pos -= transform.rotation * velocity; //shoots in current position it is facing
        transform.position = pos;
	
	}
}
