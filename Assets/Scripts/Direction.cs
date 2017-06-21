using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour {

    public float mSpeed;
    private bool mMovable;

	// Use this for initialization
	void Start () {
        mMovable = true;
	}

    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moverHorizontal, 0.0f, moverVertical);
        if (mMovable)
            transform.Translate(movement * mSpeed);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMovable(bool flag)
    {
        mMovable = flag;
    }
}
