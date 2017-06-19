using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBallController : MonoBehaviour {

    public float speed;
    private Rigidbody rigidbody;
    private bool isMoving;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(CheckMoving(0.05f));
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
            Main.AddYellowColSet(Main.REDBALL);
        else if (col.transform.tag == "RedBall2")
            Main.AddYellowColSet(Main.REDBALL2);
        else if (col.transform.tag == "WhiteBall")
            Main.AddYellowColSet(Main.WHITEBALL);
    }


    IEnumerator CheckMoving(float checkRate)
    {
        Vector3 prevPos, actualPos;

        while (true)
        {
            prevPos = rigidbody.transform.position;
            yield return new WaitForSeconds(checkRate);
            actualPos = rigidbody.transform.position;
            if (prevPos == actualPos)
            {
                Debug.Log("yellowball is stopped");
                isMoving = false;
            }
            else
            {
                Debug.Log("yellowball is moving");
                isMoving = true;
            }
        }
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
