using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour
{

    public float spd;
    public GameObject gObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCoordinates();
    }

	public void setDestination(string s) {
		gObject = GameObject.Find(s);
	}

    private void MoveTowardsCoordinates()
    {
        float speed = spd;

        //GameObject player = GameObject.Find (objectName);
        //Transform playerTransform = player.transform;

        //Vector3 targetPosition = new Vector3(x,y,z);
        Vector3 targetPosition = gObject.transform.position;
        Vector3 currentPosition = this.transform.position;
        if (Vector3.Distance(currentPosition, targetPosition) > .1f)
        {
            Vector3 directionOfTravel = targetPosition - currentPosition;
            directionOfTravel.Normalize();
            this.transform.Translate(
                (directionOfTravel.x * speed * Time.deltaTime),
                (directionOfTravel.y * speed * Time.deltaTime),
                (directionOfTravel.z * speed * Time.deltaTime),
                Space.World);
        }
    }
}