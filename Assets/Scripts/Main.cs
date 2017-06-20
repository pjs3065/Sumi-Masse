using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Main {

    public static Main instance = new Main();

    public const int REDBALL = 0;
    public const int REDBALL2 = 1;
    public const int WHITEBALL = 2;
    public const int YELLOWBALL = 3;

    private HashSet<int> mWhiteColSet = new HashSet<int>();    // white ball collision set.
    private HashSet<int> mYellowColSet = new HashSet<int>();   // yellow ball collision set.

    private int mNumPlayer = 0; // number of player.
    private int mTurn = 0;  // indicates whose turn, starts from 1.
    private bool mBall = false; // true: yellow ball, false: white ball;
    private int[] mScore = new int[4] { 0, 0, 0, 0}; // score

    private Direction cDirection = GameObject.Find("Direction").GetComponent<Direction>(); // 'Direction.cs' script reference.
    private WhiteBallController cWhiteBallController = GameObject.Find("WhiteBall").GetComponent<WhiteBallController>();   // 'WhiteBallController.cs' script reference.
    private YellowBallController cYellowBallController = GameObject.Find("YellowBall").GetComponent<YellowBallController>(); // 'YellowBallController.cs' script reference.
    private RedBall1Controller cRedBall1Controller = GameObject.Find("RedBall").GetComponent<RedBall1Controller>(); // 'RedBall1Controller.cs' script reference.
    private RedBall2Controller cRedBall2Controller = GameObject.Find("RedBall2").GetComponent<RedBall2Controller>(); // 'RedBall2Controller.cs' script reference.
    private btLauncherController cLauncherController = GameObject.Find("btLauncher").GetComponent<btLauncherController>();
    private txtScoreBoard cTxtScoreBoard = GameObject.Find("txtScoreBoard").GetComponent<txtScoreBoard>();
    private Force cForce = GameObject.Find("Force").GetComponent<Force>();

    public btLauncherController getBtLauncherController()
    {
        return cLauncherController;
    }

    public  void AddYellowColSet(int n)
    {
        mYellowColSet.Add(n);
    }

    public  void AddWhiteColSet(int n)
    {
        mWhiteColSet.Add(n);
    }

    // add force to ball
    public void Strike(float power)
    {
        mNumPlayer = 2; // for debugging

        Vector3 ballPos;    // ball position
        Vector3 forceDir; // que direction
        Vector3 forcePos; // que position

        if (mBall)  // white ball turn
            ballPos = cWhiteBallController.transform.position;
        else    // yellow ball turn
            ballPos = cYellowBallController.transform.position;

        forceDir = cDirection.transform.position - ballPos;
        forceDir.y = 0.0f;
        forceDir.Normalize();
        forcePos = ballPos - forceDir;
        cForce.Strike(forcePos, forceDir, power);

        cDirection.StartCoroutine(AfterStrike());
    }

    private  IEnumerator AfterStrike()
    {
        cLauncherController.setActive(false);
        yield return new WaitForSeconds(0.5f);
        while (cWhiteBallController.IsMoving() || cYellowBallController.IsMoving())
            yield return new WaitForSeconds(0.5f);

        if (!GetScore())  // if player get score, play once more
        {
            mBall = !mBall;
            mTurn = (mTurn + 1) % mNumPlayer;
        }
        SetScoreBoard();
        cLauncherController.setActive(true);
    }

    private  bool GetScore()
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

    private  void SetScoreBoard()
    {
        string txt = "Score\n";

        for (int i=0; i<mNumPlayer; i++)
            txt += "Player " + i + ": " + mScore[i] + "\n";
        cTxtScoreBoard.SetText(txt);
    }
}
