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
        SceneManager.LoadScene("Main");
    }
}




