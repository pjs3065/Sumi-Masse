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
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverHorizontal, 0.0f, moverVertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
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