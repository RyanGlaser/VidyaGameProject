using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;
    private GameManager gameManager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager = GameManager._instance;
        //checks to see if level has NOT been beaten, and if we are a player
        //if so, teleport
        if(gameManager.IsBossAlive(levelToLoad) && collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
