using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private GameObject noteGrouprefab;
    [SerializeField] private float noteGroupGap = 1f;
    [SerializeField]
    private KeyCode[] wholekeyCodesarr = new KeyCode[]
    {
        KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L
    };
    [SerializeField] private int initNoteGroupNum = 2;

    public static NoteManager Instance;
    private List<notegroup> notegroupList = new List<notegroup>();

    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        for (int i = 0; i < Mathf.Min(initNoteGroupNum, wholekeyCodesarr.Length); i++)
        {
            CreateNoteGroup(wholekeyCodesarr[i]);
        }
    }

    public void CreateNoteGroup()
    {
        if (notegroupList.Count < wholekeyCodesarr.Length)
        {
            CreateNoteGroup(wholekeyCodesarr[notegroupList.Count]);
        }
    }

    private void CreateNoteGroup(KeyCode keyCode)
    {
        GameObject notegroupObj = Instantiate(noteGrouprefab);
        notegroupObj.transform.position = Vector3.right * notegroupList.Count * noteGroupGap;

        notegroup notegroup = notegroupObj.GetComponent<notegroup>();
        notegroup.Create(keyCode);

        notegroupList.Add(notegroup);
    }

    public void OnInput(KeyCode keyCode)
    {
        int randId = Random.Range(0, 10);
        bool isApple = randId < 6 ? true : false; // 6/10의 확률로 사과, 4/10의 확률로 블루베리

        foreach (notegroup notegroup in notegroupList)
        {
            if (keyCode == notegroup.KeyCode)
            {
                notegroup.OnInput(isApple);
                break;
            }
        }
    }
}