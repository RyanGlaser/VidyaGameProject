using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /**
     * @author Robbie
     * This website helped me out with Unity Singleton pattern:
     *      https://www.studica.com/blog/how-to-create-a-singleton-in-unity-3d
     */
    public static bool gameManagerExists;
    public static GameManager _instance = null;
    public GameObject player;
    public GameObject gameWonMenuUI;
    private PlayerHealthManager playerHealth;
    private static bool [] bossWinConditions = {true, // 1. Water
                                                true, // 2. Earth
                                                true, // 3. Fire
                                                true};// 4. Air
                                                   

    // Use this for initialization
    void Start()
    {

        if (!gameManagerExists)
        {
            Debug.Log("creating GameManager (didn't exist)");
            gameManagerExists = true;
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Debug.Log("destroying gameObject (GameManager?)");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If ALL bosses are dead, show win screen
        if (!bossWinConditions[0] && 
            !bossWinConditions[1] &&
            !bossWinConditions[2] &&
            !bossWinConditions[3])
        {
            gameWonMenuUI.SetActive(true);
        }

    }

    //this is for each boss controller to call
    //when it has died
    public void bossDown (int num)
    {
        Debug.Log("Boss: " + num + " killed in bossDown().");
        bossWinConditions[num] = false;
    }
}
