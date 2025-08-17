using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject ballPrefab;
    public Vector3 ballSpawnPosition;
    public Text runsText;
    public int totalRuns;


    private float throwBallTimer = 0f;
    private float throwBallDelay = 4f; // Delay in seconds

    private void Awake()
    {
        Instance = this;
        UpdateRuns(0);
    }
    //public void strat()
    //{
    //    bowlerController.myAnimator2.SetBool("pitch", true);
    //    //StartCoroutine(PlayAnimation());

    //}

    private void Update()
    {
        ThrowBallTimer();
    }

    private void ThrowBallTimer()
    {
        throwBallTimer += Time.deltaTime;
        if (throwBallTimer >= throwBallDelay)
        {
          //  bowlerController.myAnimator2.SetBool("pitch", true);
            ThrowBall();
            throwBallTimer = 0f;
  
        }
    }

    public void ThrowBall()
    {
        Vector3 ballSpawnPosition = new Vector3(0.292f, 0.86f, 1.22f);
        Quaternion rotation = Quaternion.Euler(0, 180, 0);

        Instantiate(ballPrefab, ballSpawnPosition, rotation);
       
    }
    
    public void UpdateRuns(int score)
    {
        totalRuns += score;
        runsText.text = "Runs - " + totalRuns;
    }
}
