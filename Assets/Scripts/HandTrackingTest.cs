using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingTest : MonoBehaviour
{

    public GameObject indexTipObj;
    public GameObject thumbTipObj;

    public GameObject knuckleObj;
    public GameObject nerfGunObj;

    TriggerListener triggerComponent;
    NerfGunScript nerfGunComponent;

    MixedRealityPose pose;


    void Start()
    {
        indexTipObj.GetComponent<Renderer>().enabled = false;
        knuckleObj.GetComponent<Renderer>().enabled = false;
        nerfGunObj.GetComponent<Renderer>().enabled = false;

        triggerComponent = thumbTipObj.GetComponent<TriggerListener>();
        nerfGunComponent = nerfGunObj.GetComponent<NerfGunScript>();
    }

    void Update()
    {
        indexTipObj.GetComponent<Renderer>().enabled = false;
        thumbTipObj.GetComponent<Renderer>().enabled = false;

        nerfGunObj.GetComponent<Renderer>().enabled = false;
        knuckleObj.GetComponent<Renderer>().enabled = false;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            indexTipObj.transform.position = pose.Position;

            indexTipObj.GetComponent<Renderer>().enabled = true;
        }


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexKnuckle, Handedness.Right, out pose))
        {
            knuckleObj.transform.position = pose.Position;

            knuckleObj.GetComponent<Renderer>().enabled = true;

            nerfGunObj.transform.position = knuckleObj.transform.position;
            nerfGunObj.transform.Translate(-0.08f, 0.03f, 0);

            nerfGunObj.GetComponent<Renderer>().enabled = true;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbTipObj.transform.position = pose.Position;

            thumbTipObj.GetComponent<Renderer>().enabled = true;
        }


        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out pose))
        {
            nerfGunObj.transform.rotation = pose.Rotation;
            nerfGunObj.transform.Rotate(0, -70, 175);

            nerfGunObj.GetComponent<Renderer>().enabled = true;
        }

        // if trigger is pulled, shoot 
        if (thumbTipObj.GetComponent<TriggerListener>().triggerPulled && HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            nerfGunComponent.FireDart(nerfGunObj.transform.position);
        }
    }
}

