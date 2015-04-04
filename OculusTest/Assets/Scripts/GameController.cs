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

    }
}
