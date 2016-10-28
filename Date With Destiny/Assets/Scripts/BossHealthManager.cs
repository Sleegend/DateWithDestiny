using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossHealthManager : MonoBehaviour
{
    public string nextScene;

    public int maxHealth;
    public int currentHealth;

    private static bool isDead;
    private float deathCounter = 2.0f;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            deathCounter -= Time.deltaTime;
            anim.SetBool("isDead", true);
            isDead = true;
            if (deathCounter <= 0)
            {
                SceneManager.LoadScene(nextScene);
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
