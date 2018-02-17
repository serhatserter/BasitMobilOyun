using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public Transform player;
	public new Vector3 camera;
	public Quaternion baslangic;
	float camDonus, camStart,playerStart, acler, donusLimit;
	public bool sifirla,durdur;
	private PlayerMovement PScript;
	public float vertigo,camView;


	private void Start()
	{
		camera = transform.position;
		camDonus = 4f;
		donusLimit = 0.05f;
		camStart = (camera.z - playerStart);
		playerStart = player.position.z;
		baslangic = transform.rotation;
		sifirla = false;
		durdur = false;
		PScript = player.GetComponent<PlayerMovement>();

		vertigo = 10f;
		camView = Camera.main.fieldOfView;

	}

	void Update()
	{
		if (PScript.pause != true)
		{
			Vertigo();

			transform.position = new Vector3(player.position.x, player.position.y +18 , player.position.z + (camera.z-playerStart));

			if (durdur == false && PScript.yerde==true) { Hareket(); }
			if (sifirla == true)
			{
				transform.rotation = baslangic;
				sifirla = false;

			}
		}
	}


	void Hareket()
	{
		if (transform.rotation.z > -donusLimit && transform.rotation.z < donusLimit)
		{
			transform.Rotate(0, 0, (Input.acceleration.x) / camDonus);
			acler = Input.acceleration.x;
		}

		else if (Input.acceleration.x / (-acler) > 0)
		{
			transform.Rotate(0, 0, (Input.acceleration.x) / camDonus);
		}
	}

	void Vertigo()
	{
		if (PScript.hizlandi == true)
		{
			if (Camera.main.fieldOfView <= camView+10f) {
				camera = new Vector3(transform.position.x, transform.position.y, camera.z - vertigo * Time.deltaTime);
				Camera.main.fieldOfView = Camera.main.fieldOfView + vertigo * Time.deltaTime;
			}

		}
		else if (Camera.main.fieldOfView > camView)
		{
			camera = new Vector3(transform.position.x, transform.position.y, camera.z + vertigo * Time.deltaTime);
			Camera.main.fieldOfView = Camera.main.fieldOfView - vertigo * Time.deltaTime;
		}
		else
		{
			camera = new Vector3(transform.position.x, transform.position.y, camStart );
			Camera.main.fieldOfView = camView;
		}
	}
}