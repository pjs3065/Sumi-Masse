using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverHorizontal, 0.0f, moverVertical);
        transform.Translate(movement * speed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
