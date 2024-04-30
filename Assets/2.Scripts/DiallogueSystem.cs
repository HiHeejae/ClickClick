using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DiallogueSystem : MonoBehaviour
{
    public Text des;
    bool isDiallogue = false;
    public GameObject diallogueimage;
    public Button diallogueBtn;
    public GameObject birdimage;
    

    Queue<string> sentences = new Queue<string>();
    public void Begin(Diallogue info)
    {
        sentences.Clear();
        foreach (var sentence in info.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Next();
    }
    public void Next()
    {
        if (sentences.Count == 0)
        {
            End();
            return;
        }

        des.text = sentences.Dequeue();
    }

    private void End()
    {
        diallogueimage.SetActive(false);
        isDiallogue = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Next();
            birdimage.SetActive(false);
        }

    }

    public void ClickDiallogue()
    {
        diallogueimage.SetActive(true);
        isDiallogue = true;
        birdimage.SetActive(true);
    }

    private void Awake()
    {
        diallogueBtn.onClick.AddListener(ClickDiallogue);
    }
}
