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

	public void setEnemies(int numberOfEnemies)
	{
		enemies = numberOfEnemies;
	}

	public void registerDeath()
	{
		enemies--;
		if (enemies == 0) {
			Camera_Move.instance.ResumeMovement();
		}
	}

	public int getEnemyCount()
	{
		return enemies;
	}

	public void addEnemy()
	{
		++enemies;
	}

    // Update is called once per frame
    void Update()
    {
		//temp
		if (Input.GetKeyDown (KeyCode.Space)) {
			//advance the camera
			Camera_Move.instance.setRunning (!Camera_Move.instance.getRunning());
		}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //sudoku
            Application.LoadLevel("MainScene"); 
        }
    }
}
