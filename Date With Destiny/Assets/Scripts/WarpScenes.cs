using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpScenes : MonoBehaviour {

    public string loadLevel;

    public string exitPoint; // exit point for warp scenes
    private PlayerMovement thePlayer; //reference to player for warp
    // Use this for initialization
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>(); // get object with PlayerMovement script for use with warp

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.name == "Player")
        {
            thePlayer.startPoint = exitPoint;
            SceneManager.LoadScene(loadLevel);
            //thePlayer.startPoint = exitPoint; //start point is = to our exit point
        }

    }

}
