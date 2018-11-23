using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWonMenu : MonoBehaviour {

    public static bool gameOverExists;
    public GameObject player;
    public GameObject gameWinMenuUI;
    private PlayerHealthManager playerHealth;

    // Use this for initialization
    void Start()
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
        gameWinMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        gameWinMenuUI.SetActive(false);
        player.SetActive(true);
        playerHealth.SetMaxHealth();
        GameManager._instance.ResetBosses();
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
