using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public static bool musicManExists;
    public AudioSource[] musicTracks; //array of our music tracks
    public int currentTrack; //the track in our array
    public bool musicCanPlay;

	// Use this for initialization
	void Start () {
       /* if (!musicManExists)
        {
            musicManExists = true;
            DontDestroyOnLoad(transform.gameObject);
        } else
        {
            Destroy(gameObject);
        }*/
	
	}
	
	// Update is called once per frame
	void Update () {
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
	}

    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
