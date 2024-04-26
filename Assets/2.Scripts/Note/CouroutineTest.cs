using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouroutineTest : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        int counter = 0;
        while (true)
        {
            // Debug.Log(counter); // 이 부분을 주석 처리하거나 제거합니다.
            counter++;
            yield return new WaitForSeconds(1);
        }
    }
}
