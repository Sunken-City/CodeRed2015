using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
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
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
