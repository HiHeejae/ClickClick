using UnityEngine;
using UnityEngine.SceneManagement;

public class MainBtn : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        // Start ������ �̵�
        SceneManager.LoadScene("Start");
    }
}
