using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private static bool isDead;
    public float deathCounter = 2f;

    Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0)
        {
            deathCounter -= Time.deltaTime;
            anim.SetBool("isDead", true);
            isDead = true;
            if (deathCounter <= 0)
            {
                 Destroy(gameObject);
            }
            //Destroy(gameObject); // get rid of enemy, don't respawn
        }
	
	}

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
