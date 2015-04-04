using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour {

	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter(Collision col) {
		if (col.gameObject.name == "Sphere") {
			health = health - 5;
			Destroy(col.gameObject);
		}
	}
}
