using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private PlayerController player;
    private CameraController mainCamera;
    public static bool startPointExists;
    public Vector2 startDirection;

	// Use this for initialization
	void Start ()
    {
        /*
        if (!startPointExists)
        {
            startPointExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        */
        player = FindObjectOfType<PlayerController>(); 
        player.transform.position = transform.position; // moves the player to our starting point in a scence
        player.lastMove = startDirection;

        mainCamera = FindObjectOfType<CameraController>();
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z); // moves the camera to starting point in a scene
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
