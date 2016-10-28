using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Lava : MonoBehaviour {

    public string loadLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Warp Lava");

        SceneManager.LoadScene(loadLevel);
        //gameObject.SetActive(false);
    }
}
