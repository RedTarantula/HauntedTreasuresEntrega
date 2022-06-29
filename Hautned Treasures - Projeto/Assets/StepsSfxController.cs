using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class StepsSfxController : MonoBehaviour
{
    public MMFeedbacks stepFdb;
    public Animator anim;

    public void PlayFeedbackStep()
    {
        float h = Mathf.Abs(anim.GetFloat("horizontal"));
        float v = Mathf.Abs(anim.GetFloat("vertical"));

        bool hb = h > 0.9;
        bool vb = v > 0.9;
        bool b = hb || vb;
        
        if (!stepFdb.IsPlaying && b)
        {
            stepFdb.PlayFeedbacks();
        }
    }
}
