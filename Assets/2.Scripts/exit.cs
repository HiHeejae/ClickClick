using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    public Button exitButton;

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // 게임 종료
        Application.Quit();
    }
}
