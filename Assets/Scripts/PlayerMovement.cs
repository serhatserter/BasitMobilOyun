using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public Rigidbody rb;
	public float hiz,yanHiz;
	float basa, dususHiz,dustu;
	public bool yerde;
	Vector3 baslama, yurume, yereDegme;
	public Vector3 jumpPosition;
	private new GameObject camera;
	private FollowPlayer script;
	float jumpSpeed,yukseklik;
	public bool jump;

	// Use this for initialization
	void Start () {
		hiz = 50f;
		yanHiz = 50f;

		yerde = false;
		basa = -10f;

		dususHiz = -25f;
		dustu = 0.1f;

		jumpSpeed = 30f;
		jump = false;
		yukseklik = 7f;

		yurume = new Vector3(0, dususHiz, hiz);
		baslama = transform.position;

		camera = GameObject.FindWithTag("MainCamera");
		script = camera.GetComponent<FollowPlayer>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {

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
			script.sifirla = true;
			jump = false;
		}
	}

	void Jump()
	{
		if (transform.position.y >= jumpPosition.y + yukseklik)
		{
			jump = false;
			rb.velocity = new Vector3(yurume.x, -jumpSpeed, yurume.z);
		}


		if (Input.GetMouseButtonDown(0) && yerde==true){
			jumpPosition = transform.position;
			
			jump = true;
			
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
			yereDegme = transform.position;
			
		}
		
	}
}
