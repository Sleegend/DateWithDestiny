using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossDead : MonoBehaviour {

    private float sceneCountdown = 9f;

    public EnemyHealthManager enemyHealth;

    private DialogueManager diagManager;

    Animation anim;

    public string newGameLevel;
	// Use this for initialization
	void Start () {
        //enemyHealth = FindObjectOfType<EnemyHealthManager>();
        diagManager = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enemyHealth.currentHealth <= 0)
        {
            //anim.Stop();
            sceneCountdown -= Time.deltaTime;
            diagManager.ShowBox("Phew, that was tough!  Why did the programmer have to make the Boss so cheap anyways?  Oh no, I'm going to be late for my interview!  If I don't land this job, Zelda is going to make me sleep on the couch again...."); //need to set deathCounter to >0 or dies before box can appear
            //SceneManager.LoadScene(newGameLevel);

            if (sceneCountdown <= 0)
            {
                DeleteAll();
                SceneManager.LoadScene(newGameLevel);
            }

            //sceneCountdown -= Time.deltaTime;
            //DeleteAll();
            //SceneManager.LoadSceneAsync(newGameLevel);

        }

      /*  if (sceneCountdown <= 0)
        {
            SceneManager.LoadSceneAsync(newGameLevel);
        }   
        */
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }

}
