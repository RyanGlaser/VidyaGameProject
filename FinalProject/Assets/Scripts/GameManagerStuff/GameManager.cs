using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameManagerExists;
    public GameObject player;
    public enum GAME_STATES { Playing, GameOver }
    public GAME_STATES gameState = GAME_STATES.Playing;
    public GameObject gameOverCanvas;
    private PlayerHealthManager playerHealth;

    // Use this for initialization
    void Start()
    {
        if (!gameManagerExists)
        {
            gameManagerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        playerHealth = player.GetComponent<PlayerHealthManager>();
        gameOverCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GAME_STATES.Playing:
                if (playerHealth.isAlive == false)
                {
                    gameState = GAME_STATES.GameOver;
                    gameOverCanvas.SetActive(true);
                }
                break;
            case GAME_STATES.GameOver:
                break;

        }
    }
}
