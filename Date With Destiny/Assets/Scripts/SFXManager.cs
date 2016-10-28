using UnityEngine;
using System.Collections;

public class SFXManager : MonoBehaviour {

    //each sound file must have own AudioSource
    public AudioSource playerAttack; //sword swoosh
    public AudioSource hurt;
    public AudioSource dead;

    private static bool SFXManExists;

	// want SFX Manager to persist across all scenes
	void Start () {
        if (!SFXManExists)
        {
            SFXManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
