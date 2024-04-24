using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private List<KeyCode> keyCodeList = new List<KeyCode>();

    private void Awake()
    {
        Instance = this;
    }

    public void addkeycode(KeyCode keyCode)
    {
        keyCodeList.Add(keyCode);
    }

    private void Update()
    {
        if (GameManager.Instance.isGameDone)
        {
            return;
        }
        foreach (KeyCode keyCode in keyCodeList)
        {
            if (Input.GetKeyDown(keyCode) == true)
            {
                NoteManager.Instance.OnInput(keyCode);
                break;
            }
        }

     

    }
}
