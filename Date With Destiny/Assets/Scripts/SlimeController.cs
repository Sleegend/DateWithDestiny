using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SlimeController : MonoBehaviour {

    Rigidbody2D rbody;  //rigid body 2d
    Animator anim;

    public float moveSpeed = 1.0f;  //player movement speed
    private bool moving; //if enemy is currently moving

    public float timeBetweenMove = 2.0f; //time between each move
    private float timeBetweenMoveCounter; //count down to 0, then set to timeBetweenMove value

    public float moveDuration = 1.0f; //how long enemy is moving for
    private float moveDurationCounter; //count down to 0, set to timeToMove value when done

    private float attackCountdown = 0.5f;

    private Vector3 moveDirection; //direction enemy will move in

    public float timeToReload = 2.0f;
    private bool reloading;

    private GameObject thePlayer;
    private PlayerHealthManager health;

    private EnemyHealthManager enemyHealth;

    // Use this for initialization
    void Start () {

        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        //timeBetweenMoveCounter = timeBetweenMove;
        //moveDurationCounter = moveDuration;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //move between 75% or 125% of betweenMoveTime
        moveDurationCounter = Random.Range(moveDuration * 0.75f, moveDuration * 1.25f);

    }
	
	// Update is called once per frame
	void Update () {
	
        if (moving)
        {
            moveDurationCounter -= Time.deltaTime;

            if(gameObject.GetComponent<EnemyHealthManager>().currentHealth > 0)
            {
                rbody.velocity = moveDirection;
            }             

            anim.SetBool("isWalking", true);
            anim.SetFloat("x", moveDirection.x);
            anim.SetFloat("y", moveDirection.y);

            if (moveDurationCounter < 0f)
            {
                moving = false;
                //timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f); //move between 75% or 125% of betweenMoveTime
            }

        } else
        {
            timeBetweenMoveCounter -= Time.deltaTime; //counter counts down
            rbody.velocity = Vector2.zero; //stop moving the velocity

            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                //moveDurationCounter = moveDuration;
                moveDurationCounter = Random.Range(moveDuration * 0.75f, moveDuration * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0); //move x and y at random values from -1 to 1
            }
        }
        if (reloading)
        {
            timeToReload -= Time.deltaTime;
            if(timeToReload <= 0)
            {
                //loaded level is equal to current level
                Application.LoadLevel(Application.loadedLevel); //load current level
                //SceneManager.LoadScene(Application.loadedLevel);
                
                thePlayer.SetActive(true);
                thePlayer.GetComponent<PlayerHealthManager>().playerCurrentHealth = thePlayer.GetComponent<PlayerHealthManager>().playerMaxHealth;
            }
        }

	}

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.name == "Player")// && other.gameObject.GetComponent<PlayerHealthManager>().playerCurrentHealth <= 0)
        {
            attackCountdown -= Time.deltaTime;
            thePlayer = other.gameObject;
            anim.SetBool("isAttacking", true);

        }

        if (attackCountdown <= 0)
        {
            anim.SetBool("isAttacking", false);
            attackCountdown = 0.5f;
        }

        if (thePlayer.GetComponent<PlayerHealthManager>().playerCurrentHealth <= 0)
        {
            thePlayer.SetActive(false); //hidden instead of destroyed, remember to set active when level reloaded so player comes back
            reloading = true;
            //thePlayer = other.gameObject;
        }

    }
}
