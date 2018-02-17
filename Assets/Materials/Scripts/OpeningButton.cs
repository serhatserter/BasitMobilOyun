using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OpeningButton : MonoBehaviour {

	public bool yeni;


	private void Start()
	{

	}

	public void YeniOyun()
	{
		yeni = true;


	}
	public void MenuyeDon()
	{
		SceneManager.LoadScene("Opening");
	}

	public void Cikis()
	{
		Application.Quit();
	}
}
