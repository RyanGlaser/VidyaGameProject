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
    private bool [] BossWinConditions;
                                                   

    // Use this for initialization
    void Start()
    {
        ResetBosses();
        
        if (!gameManagerExists)
        {
            Debug.Log("creating GameManager (didn't exist)");
            gameManagerExists = true;
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
       /* else
        {
            Debug.Log("destroying gameObject (GameManager?)");
            Destroy(gameObject);
        } */
    }

    // Update is called once per frame
    void Update()
    {
        //If ALL bosses are dead, show win screen
        if  (CheckWin())
        {
            Debug.Log("Launching Victory Screen");
            gameWonMenuUI.SetActive(true);
        }

    }

    //this is for each boss controller to call
    //when it has died
    public void BossDown (int num)
    {
        Debug.Log("Boss: " + num + " killed in BossDown().");
        BossWinConditions[num] = false;
    }

    public void ResetBosses()
    {
        Debug.Log("Resetting Bosses");
        BossWinConditions = new bool [] {true, // 0. Water
                                         true, // 1. Earth
                                         true, // 2. Fire
                                         true};// 3. Air
    }

    private bool CheckWin()
    {
        if (BossWinConditions[0] == false)
            if (BossWinConditions[1] == false)
                if (BossWinConditions[2] == false)
                    if (BossWinConditions[3] == false)
                        return true;


        return false;
    }

}
