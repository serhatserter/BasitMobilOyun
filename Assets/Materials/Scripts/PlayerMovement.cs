using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;
	public float hiz,yanHiz, hizlanmaHiz;
	float basa, dususHiz,dustu;
	public bool yerde, hizlandi,pause;
	public Vector3 baslama, yurume, yereDegme;
	public Vector3 jumpPosition;
	private new GameObject camera; 

	private FollowPlayer script;
	float jumpSpeed,yukseklik;
	public bool jump;

	// Use this for initialization
	void Start () {

		hiz = 50f;
		yanHiz = 75f;
		hizlanmaHiz = 150f;
		hizlandi = false;
		pause = false;

		yerde = false;
		basa = -10f;

		dususHiz = -25f;
		dustu = 0.1f;

		jumpSpeed = 30f;
		jump = false;
		yukseklik = 7f;

		yurume = new Vector3(0, 0, 0);
		baslama = transform.position;

		camera = GameObject.FindWithTag("MainCamera");


		script = camera.GetComponent<FollowPlayer>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		StartGame();
	}

	void StartGame()
	{

		if (yerde == true)
		{
			Hareket();
			YanaHareket();
			DustuMu();

		}

		Jump();
		BasaDon();
	}



	void Hareket()
	{
		rb.velocity = yurume;
		yurume.y = dususHiz;
	}

	void YanaHareket()
	{	
			yurume.x = Input.acceleration.x * yanHiz;	
	}

	void DustuMu()
	{
		if (yereDegme.y - dustu >= transform.position.y)
		{
			yerde = false;
			jump = false;
			rb.velocity = new Vector3(0, dususHiz, 0);
		}
	}

	void BasaDon()
	{
		if (transform.position.y <= baslama.y + basa)
		{
			transform.position = baslama;
			yurume = new Vector3(0, 0, 0);
			script.sifirla = true;
			jump = false;
			
		}
	}

	public void JumpClick()
	{
		if (yerde == true && pause==false)
		{
			jumpPosition = transform.position;

			jump = true;

		}
	}

	void Jump()
	{
		if (transform.position.y >= jumpPosition.y + yukseklik)
		{
			jump = false;
			rb.velocity = new Vector3(yurume.x, -jumpSpeed, yurume.z);
		}

		if (jump == true) {

			rb.velocity=new Vector3(yurume.x, jumpSpeed, yurume.z);
			yerde = false;
			script.durdur = true;
		}
	}


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Yer")
		{
			yerde = true;
			jump = false;
			script.durdur = false;
			hizlandi = false;
			yereDegme = transform.position;
			yurume.z = hiz;

		}

		if (col.gameObject.tag == "Hizlanma")
		{
			yurume.z = hizlanmaHiz;
			yerde=true;
			hizlandi = true;
		}

		if (col.gameObject.tag == "Engel")
		{
			transform.position = baslama;
			yurume = new Vector3(0, 0, 0);
			script.sifirla = true;
			jump = false;
			
		}
	}
}
