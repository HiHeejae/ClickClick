using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour

{
    public static GameManager Instance;

    [SerializeField] private int maxScore = 100;
    private int score;

    public void CalculateScore(bool isApple)
    {
        if (isApple)
        {
            score++;
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
    }
    
}
