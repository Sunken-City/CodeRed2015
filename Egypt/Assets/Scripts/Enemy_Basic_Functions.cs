using UnityEngine;
using System.Collections;

public class Enemy_Basic_Functions : MonoBehaviour
{
    public int healthLossMultiplier = 1;
	public int health = 100;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hurtMe()
    {
		health -= healthLossMultiplier;
		GameController.instance.registerDeath ();
    }
}