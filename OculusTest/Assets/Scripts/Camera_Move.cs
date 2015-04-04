using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour
{
	public static Camera_Move instance;
	void Awake()
	{
		//Hostile singleton
		if (instance)
		{
			Debug.Log("Destroying irrelevant Camera_Move instance.");
			Destroy(instance.gameObject);
		}
		instance = this;
	}
	
	public float spd;
	public float rotationSpeed;
	public GameObject[] gObject;
	public GameObject[] triggerWhenArrive;
	public bool[] waitWhenArriveAt;
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
		if (running) MoveTowardsCoordinates();
	}

	public void setRunning(bool run)
	{
		running = run;
	}

	public bool getRunning()
	{
		return running;
	}

	public void nextDestination() {

		if (gObject.Length > ++targetIndex) {
			currentTarget = gObject [targetIndex];
			Debug.Log ("Targeting destination " + targetIndex);
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
			this.transform.Translate((directionOfTravel.x * speed * Time.deltaTime), (directionOfTravel.y * speed * Time.deltaTime), (directionOfTravel.z * speed * Time.deltaTime), Space.World);

			Quaternion wantedRotation = Quaternion.LookRotation(directionOfTravel);
			this.transform.rotation = Quaternion.RotateTowards (transform.rotation, wantedRotation, rotationSpeed * Time.deltaTime);
		}
		else {
			if (targetIndex + 1 < waitWhenArriveAt.Length) {
				if (waitWhenArriveAt[targetIndex + 1]) {
					running = false;
				} else {
					nextDestination();
				}
			}
			else {
				running = false;
			}

			//Invoke trigger when arrive:  if (triggerWhenArrive[targetIndex + 1] != null) triggerWhenArrive[targetIndex + 1].etc

		}
	}

	public void ResumeMovement() {
		if (running == false) {
			running = true;
			nextDestination();
		}
	}
}