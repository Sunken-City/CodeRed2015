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
    private float startTime;
    private bool shieldGrows;

    private Vector3 startSize = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 endSize = new Vector3(0.1371363f, 0.1371363f, 0.1371363f);
    private Vector3 shieldPos;
    // Use this for initialization
    void Start()
    {
        renderer = laserFinger.GetComponent<LineRenderer>();
        shieldCollision = shield.GetComponent<MeshCollider>();
        shieldRenderer = shield.GetComponent<MeshRenderer>();
        skelehand = this.GetComponent<SkeletalHand>();
        length = maximum - minimum;
        currentWidth = minimum + (length / 2);
        shieldPos = shield.transform.localPosition;
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
            shieldGrows = true;
            // raycast
            //transform.position
        }
        else
        {
            if (shieldGrows)
                startTime = Time.time;
            shieldGrows = false;
            renderer.enabled = false;
            shieldCollision.enabled = true;
            shieldRenderer.enabled = true;
            shield.GetComponent<Transform>().localScale = Vector3.Lerp(startSize, endSize, (Time.time - startTime) * 3);
        }
    }

    void LateUpdate()
    {
        shield.GetComponent<Transform>().rotation = Quaternion.identity;
        shield.transform.localPosition = shieldPos;
    }
}
