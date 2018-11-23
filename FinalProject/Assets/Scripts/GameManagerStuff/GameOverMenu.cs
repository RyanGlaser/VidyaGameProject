using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool gameOverExists;
    public GameObject player;
    public GameObject gameOverMenuUI;
    private PlayerHealthManager playerHealth;
    public Transform playerSpawnPos;

    AudioSource sourceSelect;
    AudioSource sourceVictory;
    private AudioSource gameOverSound;
    private static bool NoisePlayed = false;

	// Use this for initialization
	void Start ()
    {
        if (!gameOverExists)
        {
            gameOverExists = true;

            sourceVictory = GameObject.Find("VictorySound").GetComponent<AudioSource>();
            sourceSelect = GameObject.Find("SelectSound").GetComponent<AudioSource>();
            gameOverSound = GameObject.Find("GameOverSound").GetComponent<AudioSource>();

            if (sourceVictory == null || sourceSelect == null || gameOverSound == null)
                Debug.Log("One of the audio sources in GameOver menu is bad");
            
            DontDestroyOnLoad(transform.gameObject);
            DontDestroyOnLoad(sourceSelect);
            DontDestroyOnLoad(sourceVictory);
            DontDestroyOnLoad(gameOverSound);
        }
        else
        {
            Destroy(gameObject);
        }

        playerHealth = player.GetComponent<PlayerHealthManager>();
        gameOverMenuUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(playerHealth.isAlive == false)
        {
            // I put this here so the death noise plays once -Robbie
            if (!NoisePlayed)
                PlayDeadNoise();
            gameOverMenuUI.SetActive(true);
        }
	}

    public void Restart()
    {
        gameOverMenuUI.SetActive(false);
        sourceVictory.Play();

        player.SetActive(true);
        playerHealth.SetMaxHealth();
        playerHealth.isAlive = true;

        NoisePlayed = false;
        player.transform.position = playerSpawnPos.position;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        sourceSelect.Play();
        Application.Quit();
    }

    private void PlayDeadNoise()
    {
        NoisePlayed = true;
        Debug.Log("Playing DeadNoise");
        gameOverSound.Play();
        Debug.Log("Played DeadNoise");
    }
}
