using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class MobileJoystick : MonoBehaviour {

    public float attackDelay = 0.25f;  //so can't attack again until full animation is displayed
    private float cooldownTimer = 0; //for attacking
    private bool attacking; //is player attacking

    Animator anim;  //the animator used to draw different sprites when walking in different directions
    Rigidbody2D rbody;  //rigid body 2d

    public float maxSpeed = 2.0f;  //player movement speed
    private float currentMoveSpeed;
    public float diagonalMoveModifier; //slow down diagonal movement
    private float playerBoundaryRadius = 0.5f;

    private SFXManager SFXMan;

    private static bool playerExists;

    public string startPoint; //starting point of warp scene
    //public float rotSpeed = 0.3f;
    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //gets the Player->Animator and store it in anim
        SFXMan = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (!attacking)
        { //if attacking, can't move
          //cooldownTimer -= Time.deltaTime;

            Vector2 movement_vector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

            if (movement_vector != Vector2.zero) // if a direction is pushed
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("x", movement_vector.x);
                anim.SetFloat("y", movement_vector.y);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            //stab animation
            if (CrossPlatformInputManager.GetButton("Fire1") && movement_vector != Vector2.zero)
            {
                Debug.Log("Hit!");
                anim.SetBool("isStabbing", true);

            }
            else
            {
                anim.SetBool("isStabbing", false);
            }

            if (CrossPlatformInputManager.GetButton("Fire1") && movement_vector == Vector2.zero)
            {
                Debug.Log("Hit!");

                anim.SetBool("isStabbingIdle", true);

            }
            else
            {
                anim.SetBool("isStabbingIdle", false);
            }


            //attack animation
            if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            { //&& cooldownTimer <= 0)
                cooldownTimer = attackDelay; //attack
                attacking = true;
                rbody.velocity = Vector2.zero;
                anim.SetBool("isAttacking", true);
                Debug.Log("Hit!");
                SFXMan.playerAttack.Play();

            }

            if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0 && CrossPlatformInputManager.GetAxisRaw("Vertical") != 0)
            {
                currentMoveSpeed = maxSpeed * diagonalMoveModifier;
            }
            else
            {
                currentMoveSpeed = maxSpeed;
            }

            rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * currentMoveSpeed);

        }

        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            //anim.SetBool("isAttacking", false);
            //attacking = false;
        }

        if (cooldownTimer < 0)
        {
            attacking = false;
            anim.SetBool("isAttacking", false);
        }


        // Move the player vertically
        //transform.Translate(new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0));

        // Move the player horizontally
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0));
        /*
        // Restrict the player to the camera's boundaries
        Vector3 pos = transform.position;  //our position
        if (pos.y + playerBoundaryRadius > Camera.main.orthographicSize)  //Camera.main is camera with MainCamera tag
        {
            pos.y = Camera.main.orthographicSize - playerBoundaryRadius;  //set position to camera size
        }
        if (pos.y - playerBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + playerBoundaryRadius;
        }
        
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (pos.x + playerBoundaryRadius > widthOrtho)  //Camera.main is camera with MainCamera tag
        {
            pos.x = widthOrtho - playerBoundaryRadius;  //set position to camera size
        }
        if (pos.x - playerBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + playerBoundaryRadius;
        }
        
        transform.position = pos;  //update position
        */
    }
}

