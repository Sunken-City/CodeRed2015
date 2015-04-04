using UnityEngine;
using System.Collections;

public class Mummy_AI : MonoBehaviour {

	bool canShoot = false;
	public int secondsWait = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (canShoot) {
			// fire projectile

			//
			canShoot = false;
		} 
		else {
			WaitForSeconds(secondsWait);
			canShoot = true;
		}
	}
}
