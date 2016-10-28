using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    private Camera cam;

    //private MusicManager musicMan;

    void Start() {
        
        //musicMan = FindObjectOfType<MusicManager>();
        //musicMan.musicTracks[1].Play();

    }

    public void newGameButton(string newGameLevel)
    {
        DeleteAll();
        SceneManager.LoadScene(newGameLevel);
        //Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    public void homeButton(string newGameLevel)
    {
        DeleteAll();
        SceneManager.LoadScene(newGameLevel);
        //Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    public void exitGameButton()
    {
        Application.Quit();
    }

    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }


}
