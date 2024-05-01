using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite BlueBarrysprite;
   // [SerializeField] private Sprite eyeOpenMango;
    //[SerializeField] private Sprite eyeDownMango;
    //[SerializeField] private SpriteRenderer eyeMango;




    private bool isApple;

    public void Destroy()
    {
        if (isApple)
        {
            // 망고가 눈을 감고있는 이미지를 받아와서 설정
            SoundManager.instance.Sound(0);
            //eyeMango.sprite = eyeDownMango;
        }
        if (!isApple)
        {
            // 망고가 눈을 뜨고있는 이미지를 받아와서 설정
            SoundManager.instance.Sound(1);
            //eyeMango.sprite = eyeOpenMango;
        }
        GameObject.Destroy(gameObject);
        
    }

    
    public void DeleteNote()
    {
        GameManager.Instance.CalculateScore(isApple);
        Destroy();
    }
    internal void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : BlueBarrysprite;
    }

   
}
