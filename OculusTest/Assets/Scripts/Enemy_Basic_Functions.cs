using UnityEngine;
using System.Collections;

public class Enemy_Basic_Functions : MonoBehaviour {

	public int x, y, z;
	Color healthHue;

	// Use this for initialization
	void Start () {
		healthHue = gameObject.GetComponent<Renderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		hurtMe ();
	}

	public void hurtMe() {
		healthHue.r = healthHue.r + 1;
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", (healthHue));
	}
}
