using UnityEngine;
using System.Collections;

public class Enemy_Basic_Functions : MonoBehaviour
{
    public int healthLossMultiplier = 1;
    private Color healthHue;

    // Use this for initialization
    void Start()
    {
        healthHue = gameObject.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hurtMe()
    {
        healthHue.r = healthHue.r + healthLossMultiplier;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", (healthHue));
    }
}