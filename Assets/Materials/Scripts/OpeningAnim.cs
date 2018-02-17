using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningAnim : MonoBehaviour {

	public float x,y,z, isaret;
	public int sayac;
	public GameObject Menu , Cam, Oda,Button;

	Vector3 CamPos;
	Quaternion CamRot;

	private OpeningButton button;
	private PauseScript PS;

	Rigidbody rb;


	void Start()
	{

		PS = GetComponent<PauseScript>();
		Button = GameObject.Find("Button");
		CamPos = new Vector3(0, 20, -20);
		CamRot = Quaternion.Euler(20, 0, 0);

		rb = GetComponent<Rigidbody>();

		Menu = GameObject.Find("Panel");
		Cam = GameObject.Find("Main Camera");
		Oda = GameObject.Find("Oda");
		

		
		Button.SetActive(false);
		Oda.SetActive(false);

		button = Menu.GetComponent<OpeningButton>();
	}
	void Update () {
		if (button.yeni == true)
		{
			Menu.SetActive(false);

			CameraEffect();
			
			
		}
		else
		{
			transform.Rotate(0.5f, 0, 0);
		}
		

	}
	void CameraEffect()
	{
		Oda.SetActive(true);

		if (Cam.transform.rotation.y >= 0) Cam.transform.Rotate(0, -0.3f, 0.1f);
		if (Cam.transform.position.y<=20f) Cam.transform.Translate(0.2f, 0.1f, 0);
		if (Cam.transform.position.z >= -20f) Cam.transform.Translate(0, 0, -0.3f);
		

		else
		{
			Cam.transform.position = CamPos;
			Cam.transform.rotation = CamRot;

			rb.constraints = RigidbodyConstraints.None;
			Cam.GetComponent<FollowPlayer>().enabled = true;

			Button.SetActive(true);
			PS.PauseButton = Button;
			button.yeni = false;
			GetComponent<PlayerMovement>().enabled = true;
			GetComponent<OpeningAnim>().enabled = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "SolLevel")
		{

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		}
		if (col.gameObject.name == "OrtaLevel")
		{

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		}
		if (col.gameObject.name == "SagLevel")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
		}

	}
}
