using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class ButtonHandler : MonoBehaviour
{
    // ��ư Ŭ�� �� ȣ��Ǵ� �Լ�
    public void OnStartButtonClicked()
    {
        // Main ������ �̵�
        Scoremanager.score = 0;
        SceneManager.LoadScene("Main");
        //GameManager.Instance.Restart();
    }
}




