using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class ButtonHandler : MonoBehaviour
{
    // 버튼 클릭 시 호출되는 함수
    public void OnStartButtonClicked()
    {
        // Main 씬으로 이동
        Scoremanager.score = 0;
        SceneManager.LoadScene("Main");
        //GameManager.Instance.Restart();
    }
}




