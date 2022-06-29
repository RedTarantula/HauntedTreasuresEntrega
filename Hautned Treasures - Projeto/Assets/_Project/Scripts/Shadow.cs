using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private MMFeedbacks _spawn;
    [SerializeField] private MMFeedbacks _disolve;
    [SerializeField] private bool _isSpawn;

    private BoxCollider _box;

    private void Start()
    {
        _box = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            _spawn.PlayFeedbacks();
        }
    }

    public void SetStatus(bool status)
    {
        _isSpawn = status;
    }

    public void SetScaleBoxCollider()
    {
        _box.size = new Vector3(1,1,1);
    }
    public void Disolve()
    {
        if (_isSpawn)
        {
            _disolve.PlayFeedbacks();
        }
        
    }
}
