using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
using System.Collections.ObjectModel;
using System;

public class ObjPosWriter : MonoBehaviour {
    
    public Transform target;
    public Transform target2;
    public TextMesh coordinates;
    Vector3 vector;
    
    

    string positioninspace;
    string distance;
   
	void FixedUpdate () {

        float posx = (target2.position.x - target.position.x) * (target2.position.x - target.position.x);
        float posy = (target2.position.y - target.position.y) * (target2.position.y - target.position.y);
        float posz = (target2.position.z - target.position.z) * (target2.position.z - target.position.z);
        double magnitude = Math.Sqrt(posx + posy + posz);
        vector = target2.position-target.position;
        positioninspace = vector.ToString("F3");
        distance = magnitude.ToString("F3");
        coordinates.text = System.String.Format("{0} m \n{1}m  ", positioninspace,distance);
        

	}
}
