using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	public GameObject PauseButton, GameMenu;
	public Rigidbody rb;
	public bool pause;

	// Use this for initialization
	void Start () {
		PauseButton = GameObject.Find("Button");
		GameMenu = GameObject.Find("GameMenu");
		pause = false;
		GameMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause()
	{
		if (pause == true)
		{
			rb.constraints = RigidbodyConstraints.None;
			PauseButton.SetActive(true);
			GameMenu.SetActive(false);
			pause = false;
		}

		else
		{
			rb.constraints = RigidbodyConstraints.FreezeAll;
			PauseButton.SetActive(false);
			GameMenu.SetActive(true);
			pause = true;
		}


	}
}
