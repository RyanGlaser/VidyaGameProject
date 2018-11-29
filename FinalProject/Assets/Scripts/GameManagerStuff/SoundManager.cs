using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Useful info on static calls: https://stackoverflow.com/questions/21019492/static-member-instance-reference-issue
 */

public class SoundManager : MonoBehaviour 
{
    private string currSceneName = null;
    private static bool soundManagerExists = false;
    public static SoundManager _instance = null;
    private AudioSource [] soundList;
    public bool playerAlive = true;

    void Start()
    {
        currSceneName = SceneManager.GetActiveScene().name;

        if (currSceneName == null)
            Debug.Log("Current scene name is null in SoundManager.Start()");
        else
            Debug.Log("Current scene name is: " + currSceneName);

        if (!soundManagerExists)
        {
            Debug.Log("creating GameManager (didn't exist)");
            soundManagerExists = true;
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);

            Debug.Log("Gathering all AudioSources in Main scene");
            soundList = GameObject.Find("MusicControl").GetComponentsInChildren<AudioSource>();
            if (soundList != null)
            {
                Debug.Log("SoundList in SoundManager is: ");
                foreach (AudioSource s in soundList)
                {
                    Debug.Log(s.name);
                }
            }
            else
                Debug.Log("SoundList in SoundManager is null");

            soundList[ReturnTrackIndex("Main")].Play();
        }
    }
	
	// Update is called once per frame
	void Update () 
    {

        string newSceneName = SceneManager.GetActiveScene().name;

        //if we changed scenes, change music
        if (newSceneName != currSceneName)
        {
            Debug.Log("Finding new track");
            switch (newSceneName)
            {
                case "EarthWorldScene":
                    soundList[ReturnTrackIndex("TeleportSound")].Play();
                    soundList[ReturnTrackIndex("Main")].Stop();
                    soundList[ReturnTrackIndex("EarthWorldScene")].Play();
                    break;

                case "Main":
                    soundList[ReturnTrackIndex("TeleportSound")].Play();
                    soundList[ReturnTrackIndex(currSceneName)].Stop();
                    soundList[ReturnTrackIndex("Main")].Play();
                    break;
                
                case "WaterWorldScene":
                    soundList[ReturnTrackIndex("TeleportSound")].Play();
                    soundList[ReturnTrackIndex("Main")].Stop();
                    soundList[ReturnTrackIndex("WaterWorldScene")].Play();
                    break;

                case "FireWorldScene":
                    soundList[ReturnTrackIndex("TeleportSound")].Play();
                    soundList[ReturnTrackIndex("Main")].Stop();
                    soundList[ReturnTrackIndex("FireWorldScene")].Play();
                    break;

                case "AirWorldScene":
                    soundList[ReturnTrackIndex("TeleportSound")].Play();
                    soundList[ReturnTrackIndex("Main")].Stop();
                    soundList[ReturnTrackIndex("AirWorldScene")].Play();
                    break;
            }
            currSceneName = newSceneName;
        }
	}

    private int ReturnTrackIndex(string SceneName)
    {
        for (int i = 0; i < soundList.Length; i++)
        {
            if (soundList[i].name == SceneName)
                return i;
        }

        Debug.Log("Could not find track for " + SceneName + " in SoundManager.ReturnTrackIndex(), returning -1");
        return -1;
    }

    public void PlaySFX(string TrackName)
    {
        if (playerAlive == true)
            soundList[ReturnTrackIndex(TrackName)].Play();
        else
            Debug.Log("Sound not allowed, cannot execute PlaySFX(): " + TrackName);
    }

    public void OnWinLose(bool result)
    {
        playerAlive = false;
        soundList[ReturnTrackIndex(currSceneName)].Stop();

        if (result == true) //if person won
        {
            soundList[ReturnTrackIndex("VictorySound")].Play();
        }
        else
        {
            soundList[ReturnTrackIndex("GameOverSound")].Play();
        }
    }

    public void PlayMenuEffect()
    {
        soundList[ReturnTrackIndex("SelectSound")].Play();
    }
}
