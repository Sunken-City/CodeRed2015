using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public float minimum = 0.2f;
    public float maximum = 0.3f;

    private LineRenderer renderer;
    private float currentWidth;
    private float length;

    // Use this for initialization
    void Start()
    {
        renderer = this.GetComponent<LineRenderer>();
        length = maximum - minimum;
        currentWidth = minimum + (length / 2);
    }

    // Update is called once per frame
    void Update()
    {
        currentWidth = minimum + Mathf.PingPong(Time.time, length);
        renderer.SetWidth(currentWidth, currentWidth);
    }
}
