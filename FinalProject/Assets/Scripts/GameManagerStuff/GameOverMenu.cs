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
	// Use this for initialization
	void Start ()
    {
        if (!gameOverExists)
        {
            gameOverExists = true;
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
            gameOverMenuUI.SetActive(true);
        }
	}

    public void Restart()
    {
        gameOverMenuUI.SetActive(false);
        player.SetActive(true);
        playerHealth.SetMaxHealth();
        playerHealth.isAlive = true;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
