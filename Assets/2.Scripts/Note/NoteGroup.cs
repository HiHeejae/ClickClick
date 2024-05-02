using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class notegroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject notespawn;
    [SerializeField] private float noteGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRender;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite SelectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;
    [SerializeField] private Animation anim;
    public Animation createBlue;

    private KeyCode Keycode;
    public KeyCode KeyCode
    {
        get
        {
            return Keycode;
        }
    }


    private List<Note> noteList = new List<Note>();

    public void Create(KeyCode keyCode)
    {
        this.Keycode = keyCode;
        keyCodeTmp.text = Keycode.ToString();
        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }

        InputManager.Instance.addkeycode(keyCode);
    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(notespawn.transform);
        noteGameObj.transform.localPosition = Vector3.up * this.noteList.Count * noteGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);

        noteList.Add(note);

        // ��纣���� ��쿡�� �߰����� �̹��� ����
        if (!isApple)
        {
            note.SetSprite(false);
        }

        createBlue.Play("Blue");
    }

    public void OnInput(bool isApple)
    {
        if (noteList.Count == 0)
            return;

        //��Ʈ ����
        Note delNote = noteList[0];
        delNote.DeleteNote();
        noteList.RemoveAt(0);

        //����
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGap;

        //����
        CreateNote(isApple);

        //��Ʈ �ִϸ��̼�
        anim.Play();
        btnSpriteRender.sprite = SelectBtnSprite;
    }

    public void callAniDone()
    {
        btnSpriteRender.sprite = normalBtnSprite;
    }

}
