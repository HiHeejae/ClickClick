using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject notespawn;
    [SerializeField] private float noteGap = 6f;

    private List<Note> noteList = new List<Note>();

    void Start()
    {
        for (int i = 0; i < noteMaxNum; i++)
        {
            GameObject noteGameObj = Instantiate(notePrefab);
            noteGameObj.transform.SetParent(notespawn.transform);
            noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap; 
            Note note = noteGameObj.GetComponent<Note>();

            noteList.Add(note);
        }
    } //-16.5 16

}
