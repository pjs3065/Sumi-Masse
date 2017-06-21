using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueCamera : MonoBehaviour {

    private Camera mCam;

	// Use this for initialization
	void Start () {
        mCam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPosition(Vector3 pos)
    {
        mCam.transform.position = pos;
    }
    
    public void SetDirection(Vector3 dir)
    {
        mCam.transform.LookAt(dir);
    }
}
