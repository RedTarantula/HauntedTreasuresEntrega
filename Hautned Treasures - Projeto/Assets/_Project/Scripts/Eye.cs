using System.Collections;
using System.Collections.Generic;
using Tobii.Gaming;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public Camera camera;
    public GameObject eyeImg;
    [Range(0f,1f)]
    public float gazeScreenFactor = .5f;

    //public GameObject testObj;

    [SerializeField] private PlayerInfos _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GazePoint gazePoint = TobiiAPI.GetGazePoint();
        UserPresence userPresence = TobiiAPI.GetUserPresence();
        //userPresence = UserPresence.NotPresent;
        if (userPresence.IsUserPresent())
        {
            RaycastEyetrackerHandler(gazePoint);
            eyeImg.SetActive(true);
            Debug.Log("A user is present in front of the screen.");
        }
        else
        {
            RaycastRegularHandler();
            eyeImg.SetActive(false);
            Debug.Log("No user in front of the camera");
        }

        //Debug.Log("User presence status is: " + userPresence);

    }

    private void RaycastRegularHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {
            HandleRayHit(hit);   
        }
    }

    private void RaycastEyetrackerHandler(GazePoint gazePoint)
    {
        RaycastHit hit;
        Vector3 vector3 = new Vector3(gazePoint.Viewport.x, gazePoint.Viewport.y, 0);
        Vector3 vector32 = new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, 0);
        Ray ray = camera.ViewportPointToRay(vector3);

        eyeImg.transform.position = vector32;
        //testObj.transform.position = ray.origin;
        
        Debug.DrawRay(ray.origin,ray.direction*30f,Color.blue);

        if (Physics.Raycast(ray, out hit, 30f))
        {
            Debug.Log(hit.collider.name);
            HandleRayHit(hit);
        }
        
    }

    private void HandleRayHit(RaycastHit hit)
    {
        Transform objectHit = hit.transform;

        if (objectHit.tag == "Visible")
        {
            if (objectHit.GetComponent<Shadow>())
            {
                objectHit.GetComponent<Shadow>().Disolve();
            }

            if (objectHit.GetComponent<DestroyShadow>())
            {
                objectHit.GetComponent<DestroyShadow>().Destroy();
            }
            //Debug.Log($"objectHit :{objectHit}");
        }

        if (objectHit.CompareTag("Zombie"))
        {
            objectHit.GetComponent<Zombie>().PlayerSawZombie();
        }

        if (objectHit.CompareTag("ExorcismItem"))
        {
            GameObject obj = objectHit.gameObject;
            _player.SetLastItemOnFocus(obj);
        }
        
        if (objectHit.CompareTag("lb_bird"))
        {
            objectHit.SendMessage("Flee");
            //Debug.Log($"Scaring a bird {objectHit}",objectHit);
        }
        
    }
}
