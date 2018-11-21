using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	public void PlaySinglePlayerGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void PlayMultiPlayerGame()
    {
        SceneManager.LoadScene("PvENetworkScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


	
	

}
