using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
    public float minimum = 0.2f;
    public float maximum = 0.3f;
    public GameObject laserFinger;
    public GameObject shield;

    private LineRenderer renderer;
    private MeshCollider shieldCollision;
    private MeshRenderer shieldRenderer;
    private SkeletalHand skelehand;
    private float currentWidth;
    private float length;

    // Use this for initialization
    void Start()
    {
        renderer = laserFinger.GetComponent<LineRenderer>();
        shieldCollision = shield.GetComponent<MeshCollider>();
        shieldRenderer = shield.GetComponent<MeshRenderer>();
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
            shieldCollision.enabled = false;
            shieldRenderer.enabled = false;
            currentWidth = minimum + Mathf.PingPong(Time.time, length);
            renderer.SetWidth(currentWidth, currentWidth);
            // raycast
            //transform.position
        }
        else
        {
            renderer.enabled = false;
            shieldCollision.enabled = true;
            shieldRenderer.enabled = true;
        }
    }
}
