using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance;

    [SerializeField] private int maxScore;
    [SerializeField] private int noteGroupCreateScore = 10;
    [SerializeField] private GameObject gameclearobj;
    [SerializeField] private GameObject gameoverobj;

    private int score;
    private int nextNoteGroupUnlockCnt;
    [SerializeField] private float maxtime = 30f;

    public bool isGameDone
    {
        get
        {
            if (gameclearobj.activeSelf || gameoverobj.activeSelf)
                return true;
            else
                return false;
        }
    }

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;

            if (noteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= score)
            {
                gameclearobj.SetActive(true);
            }
        }
        else
        {
            score--;
        }
        UIManager.Instance.OnScoreChange(score, maxScore);

        
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UIManager.Instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        gameclearobj.SetActive(false);
        gameoverobj.SetActive(false);

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
        Debug.Log("Game Over..");

        gameoverobj.SetActive(true);
        
        
        
    }
    public void Restart()
    {
        Debug.Log("Game Restart!");
        SceneManager.LoadScene(0);
    }
}
