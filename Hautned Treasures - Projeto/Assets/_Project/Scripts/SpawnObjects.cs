using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

public class SpawnObjects : SerializedMonoBehaviour
{
    [SerializeField] private Transform[] _spawns;

    [SerializeField] private GameObject[] _prefabsPersonalObjects;
    [SerializeField] private GameObject[] _prefabsElementaryObjects;

    [SerializeField] private PlayerInfos _playerInfos;
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        int randSpawn1 = Random.Range(0, _spawns.Length - 1);
        int randSpawn2 = Random.Range(0, _spawns.Length - 1);
        
        GameObject personal = Instantiate(_prefabsPersonalObjects[Random.Range(0, _prefabsPersonalObjects.Length-1)],
            _spawns[randSpawn1]);
        
        personal.GetComponent<Item>().SetInfos(_playerInfos);
        
        while (randSpawn1==randSpawn2)
        { 
            randSpawn2 = Random.Range(0, _spawns.Length - 1);
        }
        
        
        GameObject elementary = Instantiate(_prefabsElementaryObjects[Random.Range(0, _prefabsElementaryObjects.Length-1)],
            _spawns[randSpawn2]);
        
        elementary.GetComponent<Item>().SetInfos(_playerInfos);

    }
    
}
