using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private NoteGroup[] noteGroupsArr;
    private void Awake()
    {
        Instance = this;
    }
    
    public void OnInput(KeyCode keyCode)
    {
        if (keyCode == KeyCode.A)
        {
            noteGroupsArr[0].OnInput(true);
        }

        if (keyCode == KeyCode.S)
        {
            noteGroupsArr[1].OnInput(true);
        }
    }

}
