using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour {

    public static bool gameOverExists;
    public GameObject player;
    public GameObject gameWinMenuUI;
    private PlayerHealthManager playerHealth;

    AudioSource sourceSelect;
    AudioSource sourceVictory;

    // Use this for initialization
    void Start()
    {
        if (!gameOverExists)
        {
            gameOverExists = true;
            sourceVictory = GameObject.Find("VictorySound").GetComponent<AudioSource>();
            sourceSelect = GameObject.Find("SelectSound").GetComponent<AudioSource>();

            if (sourceVictory == null || sourceSelect == null)
                Debug.Log("One of the audio sources in GameWon menu is bad");
            
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        playerHealth = player.GetComponent<PlayerHealthManager>();
        gameWinMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        gameWinMenuUI.SetActive(false);
        sourceVictory.Play();
        player.SetActive(true);
        playerHealth.SetMaxHealth();
        GameManager._instance.ResetBosses();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        sourceSelect.Play();
        Application.Quit();
    }
}
