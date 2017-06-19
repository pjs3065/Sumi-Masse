using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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
    private static RedBall1Controller cRedBall1Controller = GameObject.Find("RedBall").GetComponent<RedBall1Controller>(); // 'RedBall1Controller.cs' script reference.
    private static RedBall2Controller cRedBall2Controller = GameObject.Find("RedBall2").GetComponent<RedBall2Controller>(); // 'RedBall2Controller.cs' script reference.
    private static btLauncherController cLauncherController = GameObject.Find("btLauncher").GetComponent<btLauncherController>();
    
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

        if (mBall)  // white ball turn
        {
            Vector3 direction = cDirection.transform.position - cWhiteBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cWhiteBallController.AddForce(direction, power);
        }

        else    // yellow ball turn
        {
            Vector3 direction = cDirection.transform.position - cYellowBallController.transform.position;
            direction.y = 0.0f;
            direction.Normalize();
            cYellowBallController.AddForce(direction, power);
        }

        cLauncherController.setActive(false);
        Thread th = new Thread(new ThreadStart(WaitingBall));
        th.Start();
        th.Join();

        if (!GetScore())  // if player get score, play once more
        {
            mBall = !mBall;
            mTurn = (mTurn + 1) % mNumPlayer;
        }
        SetScoreBoard();
        cLauncherController.setActive(true);
    }

    private static void WaitingBall()
    {
        //while (!cWhiteBallController.IsMoving() && !cYellowBallController.IsMoving())
           // ;
        Debug.Log("waiting balls..");
        while (cWhiteBallController.IsMoving() || cYellowBallController.IsMoving())
            Debug.Log("while loop");
        Debug.Log("balls are stopped.");
    }

    private static bool GetScore()
    {
        if (mBall)  // if white ball turn
        {
            if (mWhiteColSet.Contains(YELLOWBALL))  // if white ball hit yellow ball
            {
                if (mScore[mTurn] > 0)
                    mScore[mTurn] -= 10;    // player lost score
                return false;
            }
            else if (mWhiteColSet.Contains(REDBALL) && mWhiteColSet.Contains(REDBALL2)) // if white ball hit two red ball
            {
                mScore[mTurn] += 10;    // player gets score
                return true;
            }
        }
        else   // if yellow ball turn
        {
            if (mYellowColSet.Contains(WHITEBALL))  // if yellow ball hit white ball
            {
                if (mScore[mTurn] > 0)
                    mScore[mTurn] = mScore[mTurn] - 10; // player lost score
                return false;
            }
            else if (mYellowColSet.Contains(REDBALL) && mWhiteColSet.Contains(REDBALL2))    // if yellow ball hit two red ball
            {
                mScore[mTurn] = mScore[mTurn] + 10; // player gets score
                return true;
            }
        }
        return false;   // player doesn't get or lost score
    }

    private static void SetScoreBoard()
    {
        string txt = "Score\n";

        for (int i=0; i<mNumPlayer; i++)
            txt += "Player " + i + ": " + mScore[i] + "\n";
    }
}
