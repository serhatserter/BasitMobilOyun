using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "SolLevel")
		{

			SceneManager.LoadScene("Level1");
		}
		if (col.gameObject.name == "OrtaLevel")
		{

			SceneManager.LoadScene("Level2");
		}
		if (col.gameObject.name == "SagLevel")
		{
			SceneManager.LoadScene("Level3");
		}

	}
}
