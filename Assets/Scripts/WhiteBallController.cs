using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBallController : MonoBehaviour
{
    public float speed;

    private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddForce(Vector3 movement, float speed)
    {
        rigidbody.AddForce(movement * speed);
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "RedBall")
            Main.AddWhiteColSet(Main.REDBALL);
        else if (col.transform.tag == "RedBall2")
            Main.AddWhiteColSet(Main.REDBALL2);
        else if (col.transform.tag == "YellowBall")
            Main.AddWhiteColSet(Main.YELLOWBALL);
    }
}