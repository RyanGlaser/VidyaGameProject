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
    private string currSceneName = null;
    private SoundManager dj;
                                                   

    // Use this for initialization
    void Start()
    {
        ResetBosses();
        dj = SoundManager._instance;
        currSceneName = SceneManager.GetActiveScene().name;
        if (currSceneName == null)
            Debug.Log("Current scene name is null in GameManager.Start()");
        
        if (!gameManagerExists)
        {
            Debug.Log("creating GameManager (didn't exist)");
            gameManagerExists = true;
            _instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If ALL bosses are dead, show win screen
        if (CheckWin())
        {
            dj.OnWinLose(true);
            Debug.Log("Launching Victory Screen");
            gameWonMenuUI.SetActive(true);
            ResetBosses();
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

    public bool IsBossAlive(string worldname)
    {
        Debug.Log("In GameManager.IsBossAlive()");
        switch (worldname)
        {
            case "Main":
                Debug.Log("No Boss in Main scene");
                return true;

            case "WaterWorldScene":
                if (BossWinConditions[0] == true)
                    return true;
                break;

            case "EarthWorldScene":
                if (BossWinConditions[1] == true)
                    return true;
                break;

            case "FireWorldScene":
                if (BossWinConditions[2] == true)
                    return true;
                break;

            case "AirWorldScene":
                if (BossWinConditions[3] == true)
                    return true;
                break;

            default:
                Debug.Log("Scene name unknown in GameManager.CheckBoss()");
                break;
        }

        //return false if boss is not dead, or if scene is not found (less likely)
        return false;
    }

}
