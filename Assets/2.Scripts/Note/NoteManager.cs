using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void OnInput(KeyCode keyCode)
    {
        Debug.Log("KeyCode = " + keyCode);
    }

}
