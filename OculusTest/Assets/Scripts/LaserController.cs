using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public float minimum = 0.2f;
    public float maximum = 0.3f;
    public GameObject laserFinger;

    private LineRenderer renderer;
    private SkeletalHand skelehand;
    private float currentWidth;
    private float length;

    // Use this for initialization
    void Start()
    {
        renderer = laserFinger.GetComponent<LineRenderer>();
        skelehand = this.GetComponent<SkeletalHand>();
        length = maximum - minimum;
        currentWidth = minimum + (length / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (skelehand.fingers[1].GetLeapFinger().IsExtended)
        {
            renderer.enabled = true;
            currentWidth = minimum + Mathf.PingPong(Time.time, length);
            renderer.SetWidth(currentWidth, currentWidth);
        }
        else
        {
            renderer.enabled = false;
        }

        // raycast
        //transform.position
    }
}
