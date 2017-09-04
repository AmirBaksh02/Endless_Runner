using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject player;
	public float distance = 5f;
	public float angle;
	public float height = 1.5f;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{ 
		Quaternion rotation = Quaternion.Euler (0, angle, 0);
		transform.position = player.transform.position + (rotation * Vector3.forward) * distance + Vector3.up * height;

		transform.LookAt (player.transform.position);
	}

	/*void Update()
	{
		if (Input.GetButton ("Left Bumper")) {
			
			angle -= Time.deltaTime * 360f;
		}
		else if (Input.GetButton ("Right Bumper")) {
			
			angle += Time.deltaTime * 360f;
		}*/
	}

