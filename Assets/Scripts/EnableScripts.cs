using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
public class EnableScripts : MonoBehaviour {

    public GameObject scriptsGameobjects;
    bool x = false;
    bool y = false;
    public void EnableMove()
    {
        x = true;
        if (x)
        {
            HandDraggable hand = GameObject.Find("CoordinateSystemHologram").GetComponent(typeof(HandDraggable)) as HandDraggable;
            HandDraggable hand1 = GameObject.Find("Sphere").GetComponent(typeof(HandDraggable)) as HandDraggable;
            HandRotate rot = GameObject.Find("CoordinateSystemHologram").GetComponent(typeof(HandRotate)) as HandRotate;
            hand1.enabled = true;
            hand.enabled = true;
            rot.enabled = false;
        }

       
      
    }
    public void EnableRotate()
    {
        y = true;
        if (y)
        {
            HandDraggable hand = GameObject.Find("CoordinateSystemHologram").GetComponent(typeof(HandDraggable)) as HandDraggable;
            HandRotate rot = GameObject.Find("CoordinateSystemHologram").GetComponent(typeof(HandRotate)) as HandRotate;
            HandDraggable hand1 = GameObject.Find("Sphere").GetComponent(typeof(HandDraggable)) as HandDraggable;
            hand1.enabled = false;
            hand.enabled = false;
            rot.enabled = true;
        }
    }

    

  
}
