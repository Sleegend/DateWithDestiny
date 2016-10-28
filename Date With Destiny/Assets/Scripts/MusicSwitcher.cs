using UnityEngine;
using System.Collections;

public class MusicSwitcher : MonoBehaviour {

    private MusicManager musicMan;

    public int newTrack;
    public bool switchOnStart; // switch to track as soon as scene starts

	// Use this for initialization
	void Start () {
        musicMan = FindObjectOfType<MusicManager>();

        if (switchOnStart)
        {
            musicMan.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            musicMan.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
