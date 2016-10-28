using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashFade : MonoBehaviour {

    public Image splashImage1; // our splash image
    public Image splashImage2;
    public Text text1;
    public string loadLevel;  // scene to load

	// Use this for initialization
	IEnumerator Start () { //IEnumerator allows us to deal with co-routines within a method
        splashImage1.canvasRenderer.SetAlpha(0.0f); //values of 0 makes splash image completely invisible as soon as we start the game
        splashImage2.canvasRenderer.SetAlpha(0.0f);
        text1.canvasRenderer.SetAlpha(0.0f);

        fadeIn();
        //after calling fadeIn, waits extra second before we start to fade out (2.5-1.5)
        yield return new WaitForSeconds(3.5f);
        fadeOut();
        yield return new WaitForSeconds(2.5f);
        //as soon as it fades out, loads the scene
        SceneManager.LoadScene(loadLevel);
    }

    void fadeIn()
    {
        splashImage1.CrossFadeAlpha(1.0f, 2.5f, false); ///1.0 = fully visible, 1.5 = fade in duration of 1.5 seconds
        splashImage2.CrossFadeAlpha(1.0f, 2.5f, false);
        text1.CrossFadeAlpha(1.0f, 2.5f, false);
    }
	
    void fadeOut()
    {
        splashImage1.CrossFadeAlpha(0.0f, 2.5f, false); //0.0 = become invisible over span of 2.5 seconds
        splashImage2.CrossFadeAlpha(0.0f, 2.5f, false);
        text1.CrossFadeAlpha(0.0f, 2.5f, false);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
