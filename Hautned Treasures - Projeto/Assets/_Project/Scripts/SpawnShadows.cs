using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnShadows : SerializedMonoBehaviour
{
    [SerializeField] private Transform[] _spawns;

    [SerializeField] private GameObject[] _prefabsShadowObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int randSpawn1 = Random.Range(0, _spawns.Length - 1);

        GameObject shadow = Instantiate(_prefabsShadowObjects[Random.Range(0, _prefabsShadowObjects.Length-1)],
            _spawns[randSpawn1].position,Quaternion.identity,_spawns[randSpawn1]);
        
    }
}
