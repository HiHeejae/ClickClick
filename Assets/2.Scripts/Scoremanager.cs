using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoremanager : MonoBehaviour
{
    public TextMeshProUGUI scoreTmp;
    public TextMeshProUGUI bestscoreTmp;
    public static int score;
    public static int bestscore;

    public void Update()
    {

        Debug.Log("ScoreManager start1 ");
        scoreTmp.text = $"Score : {score}";
        bestscoreTmp.text = $"Best Score : {bestscore}";

    }



}
