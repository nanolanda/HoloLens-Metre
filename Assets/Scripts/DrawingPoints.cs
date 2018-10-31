using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;
using HoloToolkit;
public class DrawingPoints : MonoBehaviour,IInputClickHandler,IInputHandler {

    public GameObject coordinate;
    public Transform parent;
    public GameObject gameob;
    public RaycastHit hitInfo;
    Quaternion x;
    GestureRecognizer gesture;
    public int numberofCoordinatesLimit;
    int cont=0;
    public void OnInputClicked(InputClickedEventData eventData)
    {
        // AirTap code goes here
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            Instantiate(coordinate, hitInfo.point, x,parent);
            cont += 1;
        }            
    }
    public void OnInputDown(InputEventData eventData)
    {
        if (numberofCoordinatesLimit <= cont)
        {
            Destroy(gameob);
        }
    }
    public void OnInputUp(InputEventData eventData)
    {
        

    }
    

   
}
