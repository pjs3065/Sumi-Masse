using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBallController : MonoBehaviour {

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
}
