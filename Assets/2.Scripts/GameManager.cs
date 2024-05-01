using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

//using UnityEngine;
//using UnityEngine.SceneManagement; // SceneManager를 사용하기 위해 추가

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;


    private bool isgameClear;
    private bool isgameOver;

    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime = 30f;


    public bool isGameDone
    {
        get
        {
            if (isgameClear || isgameOver)
                return true;
            else
                return false;
        }
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            Scoremanager.score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= Scoremanager.score)
            {
                SceneManager.LoadScene("gameclear");
            }
        }
        else
        {
            Scoremanager.score--;
        }
        UIManager.Instance.OnScoreChange(Scoremanager.score, maxScore);


    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(Scoremanager.score, maxScore);
        NoteManager.Instance.Create();
        

        StartCoroutine(TimerCouroutine());
    }

    IEnumerator TimerCouroutine()
    {
        float currentTime = 0f;
        while (currentTime < maxtime)
        {
            currentTime += Time.deltaTime;
            UIManager.Instance.OnTimerChange(currentTime, maxtime);
            yield return null;

            if (isGameDone)
            {
                yield break;
            }
        }
        Debug.Log($"score : {Scoremanager.score}, bestScore  : {Scoremanager.bestscore}");
        if (Scoremanager.score > Scoremanager.bestscore)
        {
            Scoremanager.bestscore = Scoremanager.score;
            Debug.Log("bestscore change "+ Scoremanager.bestscore);
        }
        SceneManager.LoadScene("gameover") ;


    }
    //public void Restart()
    //{
    //    Scoremanager.score = 0;
    //    Debug.Log("Game Restart!");
    //    SceneManager.LoadScene("Main");
    //}
}


public class Example : MonoBehaviour
{
    void Start()
    {
        // 디버그 로그를 출력할 때만 콘솔에 표시되도록 함
        Debug.Log("This is a debug message.");
    }

}

