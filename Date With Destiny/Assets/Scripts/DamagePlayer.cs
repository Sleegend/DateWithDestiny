using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
    public int damage;
    private EnemyHealthManager enemyHealth;

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player") {

           /* if(gameObject.tag == "Spit")
            {
                other.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(1);
            } else
            {
                if (gameObject.GetComponent<EnemyHealthManager>().currentHealth > 0)
                {
                    other.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damage);
                }
            }
            */

            if (gameObject.GetComponent<EnemyHealthManager>().currentHealth > 0)
            {
                other.gameObject.GetComponent<PlayerHealthManager>().DamagePlayer(damage);
            }

        }

    }
}
