using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class SFXManagers : MonoBehaviour
{
    public MMFeedbacks[] ambienceSfxs;
    public int sfxAtATimeMin;
    public int sfxAtATimeMax;
    public float timeBetweenPlaysMin;
    public float timeBetweenPlaysMax;
    private float _timer;

    private void Start()
    {
        SetTimer();
    }

    [Button]
    private void FindAllSFxs()
    {
        ambienceSfxs = GetComponentsInChildren<MMFeedbacks>();
    }
    
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            SetTimer();
            PlaySounds();
        }
    }

    private void PlaySounds()
    {
        int r = Random.Range(sfxAtATimeMin, sfxAtATimeMax);
        List<int> toPlay = new List<int>();
        for (int i = 0; i < r; i++)
        {
            int s = Random.Range(0, ambienceSfxs.Length);
            if (!toPlay.Contains(s))
            {
                toPlay.Add(s);
            }
        }

        foreach (int i in toPlay)
        {
            ambienceSfxs[i].PlayFeedbacks();
        }
    }

    private void SetTimer()
    {
        _timer = Random.Range(timeBetweenPlaysMin, timeBetweenPlaysMax);
    }
}
