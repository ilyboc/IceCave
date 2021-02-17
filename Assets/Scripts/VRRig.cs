using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    public float turnSmoothness = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        XRRig rig = FindObjectOfType<XRRig>();
        head.vrTarget = rig.transform.Find("Camera Offset/Main Camera");
        leftHand.vrTarget = rig.transform.Find("Camera Offset/LeftHand Controller");
        rightHand.vrTarget = rig.transform.Find("Camera Offset/RightHand Controller");
        
        headBodyOffset = transform.position - headConstraint.position;
        StartDerived();
    }

    protected virtual void StartDerived()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CanMapTransform())
        {
            transform.position = headConstraint.position + headBodyOffset;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

            head.Map();
            leftHand.Map();
            rightHand.Map();
        }
    }

    protected virtual bool CanMapTransform()
    {
        return true;
    }
}
