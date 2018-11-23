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

	// Use this for initialization
	void Start ()
    {
        if (!gameOverExists)
        {
            gameOverExists = true;

            sourceVictory = GetComponent<AudioSource>();
            sourceSelect = GetComponent<AudioSource>();

            if (sourceVictory == null /*|| sourceSelect == null*/)
                Debug.Log("One of the audio sources in GameOver menu is bad");
            
            DontDestroyOnLoad(transform.gameObject);
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
            sourceVictory.Play();
            while (sourceVictory.isPlaying) {}
            gameOverMenuUI.SetActive(true);

        }
	}

    public void Restart()
    {
        sourceSelect.Play();

        gameOverMenuUI.SetActive(false);
        player.SetActive(true);
        playerHealth.SetMaxHealth();
        playerHealth.isAlive = true;
        player.transform.position = playerSpawnPos.position;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        sourceSelect.Play();
        Application.Quit();
    }
}
