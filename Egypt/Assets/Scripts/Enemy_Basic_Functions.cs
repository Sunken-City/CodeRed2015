using UnityEngine;
using System.Collections;

public class Enemy_Basic_Functions : MonoBehaviour
{
    public float healthLossMultiplier = 0.01f;
    private Color healthHue;

    // Use this for initialization
    void Start()
    {
        healthHue = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hurtMe()
    {
        healthHue.r += healthLossMultiplier;
        print(healthHue.r);
        gameObject.GetComponent<Renderer>().material.SetColor ("_TintColor", healthHue);
        if (healthHue.r >= 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}