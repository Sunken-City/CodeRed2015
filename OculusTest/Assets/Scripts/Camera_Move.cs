using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour
{
	public static Camera_Move instance;

	public float spd;
	public GameObject[] gObject;
	private int targetIndex = 0;
	
	private GameObject currentTarget;
	private bool running;
	
	// Use this for initialization
	void Start()
	{
		currentTarget = gObject [targetIndex];
		running = true;
		Debug.Log ("Targeting destination " + targetIndex);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(running)
			MoveTowardsCoordinates();
	}

	public void setRunning(bool run)
	{
		running = run;
	}
	
	public void nextDestination() {
		if (gObject.Length > ++targetIndex) {
			currentTarget = gObject [targetIndex];
			Debug.Log ("Targeting destination " + targetIndex);
		} else {

		}
	}
	
	private void MoveTowardsCoordinates()
	{
		float speed = spd;
		
		//GameObject player = GameObject.Find (objectName);
		//Transform playerTransform = player.transform;
		
		//Vector3 targetPosition = new Vector3(x,y,z);
		Vector3 targetPosition = currentTarget.transform.position;
		Vector3 currentPosition = this.transform.position;
		if (Vector3.Distance(currentPosition, targetPosition) > 1f)
		{
			Vector3 directionOfTravel = targetPosition - currentPosition;
			directionOfTravel.Normalize();
			this.transform.Translate(
				(directionOfTravel.x * speed * Time.deltaTime),
				(directionOfTravel.y * speed * Time.deltaTime),
				(directionOfTravel.z * speed * Time.deltaTime),
				Space.World);
		}
		else {
			nextDestination();
		}
	}
}