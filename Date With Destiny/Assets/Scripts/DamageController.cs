using UnityEngine;
using System.Collections;

// damage controller attached to sword
public class DamageController : MonoBehaviour {
    public int damage;
    public GameObject hitSpark;  //the hit spark particle system
    //public Transform sparkPoint;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Smack");
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthManager>().damageEnemy(damage);
            Instantiate(hitSpark, transform.position, transform.rotation);  //hitspark for sword, using swords position and rotation
        }
    }
}
