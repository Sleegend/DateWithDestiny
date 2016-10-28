using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public GameObject arrowPrefab;
    // Use this for initialization
    public float attackDelay = 0.25f;  //so can't attack again until full animation is displayed
    float cooldownTimer = 0;
    public Vector3 arrowOffset = new Vector3(0, 0.75f, 0);

    // Update is called once per frame
    void Update () {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("Hit!");
            cooldownTimer = attackDelay; //attack

            Vector3 offset = transform.rotation * arrowOffset; //need transform.rotation to work whichever direction we face to shoot, 0.5f(y) is our forward direction

            Instantiate(arrowPrefab, transform.position - offset, transform.rotation);  //transform.position is players position, transform.rotation is players rotation
        }
	
	}
}
