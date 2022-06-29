using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEditor;
using UnityEngine;

public class teste : MonoBehaviour
{
    public Camera camera;

    // Update is called once per frame
    void Update()
    {

        GazePoint gazePoint = TobiiAPI.GetGazePoint();
   

        UserPresence userPresence = TobiiAPI.GetUserPresence();
        if (userPresence.IsUserPresent())
        {
            
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay (new Vector3(gazePoint.Screen.x,gazePoint.Screen.y,0));

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                if (objectHit.tag == "Visible")
                {
                    
          
                    Debug.Log($"objectHit :{objectHit}");
                }
           
            }
            
            Debug.Log("A user is present in front of the screen.");
        }

        Debug.Log("User presence status is: " + userPresence);

        Debug.Log($"GetFocusedObject: {TobiiAPI.GetFocusedObject()}");
        // Debug.Log($"GetGazePoint: {TobiiAPI.GetGazePoint()}");
        //  Debug.Log($"GetHeadPose: {TobiiAPI.GetHeadPose()}");


      

        // Do something with the object that was hit by the raycast.
    }
}

