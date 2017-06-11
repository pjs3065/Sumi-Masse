using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Main {

    private static int mNumPlayer = 0; // number of player.
    private static int mTurn = 1;  // indicates whose turn, starts from 1.
    private static bool mBall = false; // true: yellow ball, false: white ball;

    private static Direction cDirection = GameObject.Find("Direction").GetComponent<Direction>(); // 'Direction.cs' script reference.
    private static WhiteBallController cWhiteBallController = GameObject.Find("WhiteBall").GetComponent<WhiteBallController>();   // 'WhiteBallController.cs' script reference.
    private static YellowBallController cYellowBallController = GameObject.Find("YellowBall").GetComponent<YellowBallController>(); // 'YellowBallController.cs' script reference.
    
    // setter method of 'mDirection' member variable.
    public static void setDirection(Vector3 vector)
    {
        
    }

    // add force to ball
    // for debugging
    public static void Launch(float power)
    {
        mNumPlayer = 2;

        if (mBall)  // white ball
        {
            Vector3 direction = cDirection.transform.position - cWhiteBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cWhiteBallController.AddForce(direction, power);
        }

        else
        {
            Vector3 direction = cDirection.transform.position - cYellowBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cYellowBallController.AddForce(direction, power);
        }

        setScore();
        mBall = !mBall;
        mTurn = (mTurn + 1) % mNumPlayer;
    }
    /*
    // add force to ball
    public void Launch(float power)
    {
        // if no direction selected, no action.
        if (!mDirectionSelected)
            return;
        else
            mDirectionSelected = false;

        if (mBall)  // white ball
            cWhiteBallController.AddForce(mDirection, power);
        else
            cYellowBallController.AddForce(mDirection, power);

        this.setScore();
        mBall = !mBall;
        mTurn = (mTurn + 1) % mNumPlayer;
    }
    */

    private static void setScore()
    {

    }
}
