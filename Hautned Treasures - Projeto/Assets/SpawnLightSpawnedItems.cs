using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLightSpawnedItems : MonoBehaviour
{
    public GameObject lightPrefab;
    private List<GameObject> lights = new List<GameObject>();
    private ExorcismItemInstance[] getChildren;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P");
            SpawnLights();
        }
    }

    private void SpawnLights()
    {
        if (lights.Count > 0)
        {
            foreach (GameObject o in lights)
            {
                Destroy(o);
            }

            lights = new List<GameObject>();
            return;
        }
        

        getChildren = transform.GetComponentsInChildren<ExorcismItemInstance>();
        for (int i = 0; i < getChildren.Length; i++)
        {
            GameObject obj = Instantiate(lightPrefab,gameObject.transform);
            Vector3 transformPosition = getChildren[i].transform.position;
            obj.transform.position =
                new Vector3(transformPosition.x, transformPosition.y + 5, transformPosition.z);
            lights.Add(obj);
        }
    }
}
