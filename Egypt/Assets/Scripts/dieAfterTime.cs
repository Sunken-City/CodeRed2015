using UnityEngine;
using System.Collections;

public class dieAfterTime : MonoBehaviour
{
    public float lifetime = 10.0f;
    private float birthday;
    // Use this for initialization
    void Start()
    {
        birthday = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - birthday > lifetime)
        {
            Destroy(this.gameObject);
        }
    }
}
