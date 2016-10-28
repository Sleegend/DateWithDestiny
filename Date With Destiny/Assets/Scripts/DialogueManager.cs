using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class DialogueManager : MonoBehaviour {

    public GameObject dialogueBox; //dialogue box
    public Text dialogueText;  //dialogue text

    public bool dialogActive; //is dialogue box active

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //for keyboard
        //if (dialogActive && Input.GetButton("Fire1"))

        //for mobile joystick
        if (dialogActive && CrossPlatformInputManager.GetButton("Fire1"))
        {
            dialogueBox.SetActive(false);
            dialogActive = false;
        }
	
	}

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dialogueBox.SetActive(true);
        dialogueText.text = dialogue;
    }
}
