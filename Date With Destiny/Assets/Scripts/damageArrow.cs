using UnityEngine;
using System.Collections;

public class damage : MonoBehaviour {

    public int health = 1;
    public float invinciblePeriod = 0;  //need to set to 0 so enemies aren't invincible as well
    float invincibleTimer = 0;
    int playerLayer;

    void Start()
    {
        playerLayer = gameObject.layer;
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!"); // print Trigger when trigger (hit) occurs
        //health--;
        invincibleTimer = invinciblePeriod;  
        gameObject.layer = 10; //Tags and Layers -> 10 is invincibility layer
    }
	
	// Update is called once per frame
	void Update () {

        invincibleTimer -= Time.deltaTime; //remove amount of time since last frame: needed to make it 2 seconds of time
        if(invincibleTimer <= 0) //when invincibility runs out
        {
            // gameObject.layer = 8; //set layer back to 8 (no invincibility anymore) or:
            gameObject.layer = playerLayer;
        }
	    if(health <= 0)
        {
            Die();
        }
	}

    void Die()
    {
        Destroy(gameObject);  //player disappears and dies
    }
}
