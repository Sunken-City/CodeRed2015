using UnityEngine;
using System.Collections;

public class RoomControllerExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		room1 ();
	}

	private void room1() {
		//spawn enemies here
		GameController.instance.addEnemy();
		GameController.instance.addEnemy();
		GameController.instance.addEnemy();
		Debug.Log("There are now " + GameController.instance.getEnemyCount() + " enemies left.");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && GameController.instance.getEnemyCount() > 0) {
			GameController.instance.killEnemy();
			Debug.Log("There are now " + GameController.instance.getEnemyCount() + " enemies left.");
		}
		if (GameController.instance.getEnemyCount () == 0) {
			Debug.Log("oshiiii--");
		}
	}
}
