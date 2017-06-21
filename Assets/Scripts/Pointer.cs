using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {
    private GameObject mPointer;
    public float mSpeed;
    private Camera mCam;
    private bool mMovable;

	// Use this for initialization
	void Start () {
        mPointer = GameObject.Find("Pointer");
        mMovable = false;
        mCam = GameObject.Find("CueCamera").GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        
        if (mMovable)
        {
            transform.position += mCam.transform.right * moverHorizontal * mSpeed;
            transform.position += mCam.transform.up * moverVertical * mSpeed;
        }
    }

    public void SetPosition(Vector3 pos)
    {
        mPointer.transform.position = pos;
    }

    public Vector3 GetPosition()
    {
        return mPointer.transform.position;
    }

    public void SetMovable(bool flag)
    {
        mMovable = flag;
    }
}
