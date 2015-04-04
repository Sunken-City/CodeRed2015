using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	private int enemies;

    public static GameController instance;
    void Awake()
    {
        //Hostile singleton
        if (instance)
        {
            Debug.Log("Destroying irrelevant GameController instance");
            Destroy(instance.gameObject);
        }
        instance = this;
		enemies = 0;
    }

    // Use this for initialization
    void Start()
    {
		//Camera_Move.instance.setRunning (false);
    }

	public int getEnemyCount()
	{
		return enemies;
	}

	public void addEnemy()
	{
		++enemies;
	}

	public void killEnemy()
	{
		--enemies;
	}

    // Update is called once per frame
    void Update()
    {
		//temp
		if (Input.GetKeyDown (KeyCode.Space)) {
			//advance or stop the camera
			Camera_Move.instance.setRunning (!Camera_Move.instance.getRunning());
		}
    }
}
