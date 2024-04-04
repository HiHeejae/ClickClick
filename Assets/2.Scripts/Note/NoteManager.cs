using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager Instance;
    [SerializeField] private notegroup[] noteGroupsArr;
    private void Awake()
    {
        Instance = this;
    }
    
    public void OnInput(KeyCode keyCode)
    {
        int randld = Random.Range(0, noteGroupsArr.Length);
        bool isApple = randld == 0 ? true : false;

        foreach (notegroup notegroup in noteGroupsArr)
        {
            if (keyCode == notegroup.KeyCode)
            {
                notegroup.OnInput(isApple);
            }
        }

        if (keyCode == KeyCode.A)
        {
            noteGroupsArr[0].OnInput(isApple);
        }

        if (keyCode == KeyCode.S)
        {
            noteGroupsArr[1].OnInput(isApple);
        }
    }

}
