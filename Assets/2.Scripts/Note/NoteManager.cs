using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    [SerializeField] private KeyCode[] initKeyCodeArr;
    [SerializeField] private GameObject noteGrouprefab;
    [SerializeField] private float noteGroupGap = 1f;
    public static NoteManager Instance;
    private List<notegroup> notegroupList = new List<notegroup>();
    private void Awake()
    {
        Instance = this;
    }

    public void Create()
    {
        foreach(KeyCode keyCode in initKeyCodeArr)
        {
            CreateNoteGroup(keyCode);
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
        int randld = Random.Range(0, notegroupList.Count);
        bool isApple = randld == 0 ? true : false;

        foreach (notegroup notegroup in notegroupList)
        {
            if (keyCode == notegroup.KeyCode)
            {
                notegroup.OnInput(isApple);
            }
        }
    }

}
