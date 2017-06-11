using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Main {

    public const int REDBALL = 0;
    public const int REDBALL2 = 1;
    public const int WHITEBALL = 2;
    public const int YELLOWBALL = 3;

    private static HashSet<int> mWhiteColSet = new HashSet<int>();    // white ball collision set.
    private static HashSet<int> mYellowColSet = new HashSet<int>();   // yellow ball collision set.

    private static int mNumPlayer = 0; // number of player.
    private static int mTurn = 0;  // indicates whose turn, starts from 1.
    private static bool mBall = false; // true: yellow ball, false: white ball;
    private static int[] mScore = new int[4] { 0, 0, 0, 0}; // score

    private static Direction cDirection = GameObject.Find("Direction").GetComponent<Direction>(); // 'Direction.cs' script reference.
    private static WhiteBallController cWhiteBallController = GameObject.Find("WhiteBall").GetComponent<WhiteBallController>();   // 'WhiteBallController.cs' script reference.
    private static YellowBallController cYellowBallController = GameObject.Find("YellowBall").GetComponent<YellowBallController>(); // 'YellowBallController.cs' script reference.

    public static void AddYellowColSet(int n)
    {
        mYellowColSet.Add(n);
    }

    public static void AddWhiteColSet(int n)
    {
        mWhiteColSet.Add(n);
    }

    // add force to ball
    public static void Launch(float power)
    {
        mNumPlayer = 2; // for debugging

        if (mBall)  // white ball
        {
            Vector3 direction = cDirection.transform.position - cWhiteBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cWhiteBallController.AddForce(direction, power);
        }

        else    // yellow ball
        {
            Vector3 direction = cDirection.transform.position - cYellowBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cYellowBallController.AddForce(direction, power);
        }
        
        if (!CountScore())
        {
            mBall = !mBall;
            mTurn = (mTurn + 1) % mNumPlayer;
        }
    }

    private static bool CountScore()
    {
        if (mBall)
        {
            if (mWhiteColSet.Contains(YELLOWBALL))
            {
                if (mScore[mTurn] != 0)
                {
                    mScore[mTurn] = mScore[mTurn] - 10;
                }
                return false;
            }
            else if (mWhiteColSet.Contains(REDBALL) && mWhiteColSet.Contains(REDBALL2))
            {
                mScore[mTurn] = mScore[mTurn] + 10;
                return true;
            }
        }

        else
        {
            if (mYellowColSet.Contains(WHITEBALL))
            {
                if (mScore[mTurn] != 0)
                {
                    mScore[mTurn] = mScore[mTurn] - 10;
                }
                return false;
            }
            else if (mYellowColSet.Contains(REDBALL) && mWhiteColSet.Contains(REDBALL2))
            {
                mScore[mTurn] = mScore[mTurn] + 10;
                return true;
            }
        }
        return false;
    }

    private static void RefreshScoreBoard()
    {
        string txt = "Score\n";

        for (int i=0; i<mNumPlayer; i++)
            txt += "Player " + i + ": " + mScore[i] + "\n";
    }
}
