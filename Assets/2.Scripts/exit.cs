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
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        exitButton.onClick.AddListener(ExitGame);
    }

    void ExitGame()
    {
        // ���� ����
        Application.Quit();
    }
}
