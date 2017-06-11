using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btLauncherController : MonoBehaviour {
    
    WhiteBallController whiteBall;

	// Use this for initialization
	void Start () {
        this.whiteBall = GameObject.Find("WhiteBall").GetComponent<WhiteBallController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Launch()
    {
        Vector3 movement = new Vector3(0.5f, 0.0f, 0.5f);
        whiteBall.AddForce(movement, 500);
    }
}
