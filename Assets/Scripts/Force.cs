using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

    private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Strike(Vector3 position, Vector3 direction, float speed)
    {
        rigidbody.transform.position = position;
        rigidbody.AddForce(direction * speed);
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody.transform.position = new Vector3(-50, -50, -50);
    }
}
