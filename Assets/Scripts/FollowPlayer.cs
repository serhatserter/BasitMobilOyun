
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public Transform player;
	private new Vector3 camera;
	public Quaternion baslangic;
	float camDonus;
	public bool sifirla,durdur;


	private void Start()
	{
		camera = transform.position;
		camDonus = 3f;
		baslangic = transform.rotation;
		sifirla = false;
		durdur = false;
			
	}

	void Update()
	{
		transform.position = player.position + camera;

		if (durdur == false) { Hareket(); }
		if (sifirla == true)
		{
			transform.rotation = baslangic;
			sifirla = false;
		}
		
	}


	void Hareket()
	{
		transform.Rotate(0, 0, (Input.acceleration.x) / camDonus);
	}
}