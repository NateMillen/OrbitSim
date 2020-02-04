using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public Rigidbody2D rb;
    public static List<Attractor> atts;

    public Vector2 startingforce;

    private void Start()
    {
        rb.AddForce(startingforce);
    }
    private void FixedUpdate()
    {
        foreach ( Attractor a in atts)
        {
            if(a != this)
            Attract(a);
        }
    }

    private void OnEnable()
    {
        if (atts == null)
        {
            atts = new List<Attractor>();
        }

        atts.Add(this);
    }

    private void OnDisable()
    {
        atts.Remove(this);
    }

    void Attract(Attractor a)
    {
        Rigidbody2D rbA = a.rb;

        Vector2 dir = rb.position - rbA.position;
        float dist = dir.magnitude;

        float forceMag = (rb.mass * rbA.mass) / Mathf.Pow(dist, 2);
        Vector2 force = dir.normalized * forceMag;

        rbA.AddForce(force);
    }
}
