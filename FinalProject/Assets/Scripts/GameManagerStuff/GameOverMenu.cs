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
    private bool NoisePlayed = false;
    private SoundManager dj;

	// Use this for initialization
	void Start ()
    {
        if (!gameOverExists)
        {
            gameOverExists = true;
            dj = SoundManager._instance;
            DontDestroyOnLoad(gameObject);
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
            Debug.Log("Player dead");
            // I put this here so the death noise plays once -Robbie
            if (!NoisePlayed)
            {
                NoisePlayed = true;
                Debug.Log("Before OnWinLose");
                dj.OnWinLose(false);
                Debug.Log("After OnWinLose");
            }
            Debug.Log("Before gameOver UI");
            gameOverMenuUI.SetActive(true);
            Debug.Log("After gameOver UI");
        }

	}

    public void Restart()
    {
        gameOverMenuUI.SetActive(false);
        dj.PlayMenuEffect();
        dj.playerAlive = true;
        player.SetActive(true);
        playerHealth.SetMaxHealth();
        playerHealth.isAlive = true;
        GameManager._instance.ResetBosses();

        NoisePlayed = false;
        player.transform.position = playerSpawnPos.position;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        dj.PlayMenuEffect();
        Application.Quit();
    }

}
