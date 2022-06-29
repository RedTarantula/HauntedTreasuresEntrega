using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
    public Transform playerTf;

    public GameObject zombie;
    public Transform zombieTf;

    public List<Transform> spawnPoints;

    private float DistancePlayerZombie()
    {
        return Vector3.Distance(playerTf.position, zombieTf.position);
    }

    public Vector3 GetBestPoint()
    {
        Vector3 pos = zombieTf.position;
        float distance = float.MinValue;

        Vector3 pos2 = zombieTf.position;
        float distance2 = float.MinValue;
        
        foreach (Transform spawnPoint in spawnPoints)
        {
            float dist = Vector3.Distance(spawnPoint.position, playerTf.position);
            if (dist > distance)
            {
                pos2 = pos;
                distance2 = distance;
                
                pos = spawnPoint.position;
                distance = dist;
            }
            else if ( dist > distance2)
            {
                pos2 = spawnPoint.position;
                distance2 = dist;
            }
        }

        int r = Random.Range(0, 2);
        if (r == 0)
        {
            return pos;
        }
        else
        {
            return pos2;
        }
        
    }
}
