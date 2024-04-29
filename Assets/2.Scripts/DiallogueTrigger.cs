using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiallogueTrigger : MonoBehaviour

{


    public Diallogue info;

    public void Trigger()
    {
        var system = FindObjectOfType<DiallogueSystem>();
        system.Begin(info);
        
    }

}
