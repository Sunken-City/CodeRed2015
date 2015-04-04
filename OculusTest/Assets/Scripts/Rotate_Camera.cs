using UnityEngine;
using System.Collections;

public class Rotate_Camera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float rotateX = Random.Range (0, 50);
		transform.eulerAngles = new Vector3(0,0,rotateX);
	}
}
