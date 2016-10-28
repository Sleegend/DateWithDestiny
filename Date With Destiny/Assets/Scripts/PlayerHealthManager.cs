using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;

    private EnemyHealthManager enemyHealth;

    private SFXManager SFXMan;
	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth; //when game starts, player has max health
        SFXMan = FindObjectOfType<SFXManager>();
        enemyHealth = FindObjectOfType<EnemyHealthManager>();
	}

    // Update is called once per frame
    void Update() {
        if (playerCurrentHealth <= 0)
        {
            SFXMan.dead.Play();
            gameObject.SetActive(false); //gameObject is the object this script is attached to (player)
        }
    }
	
    public void DamagePlayer(int damage)
    {
        playerCurrentHealth -= damage;
        SFXMan.hurt.Play();
    }

    public void setMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

	
}
