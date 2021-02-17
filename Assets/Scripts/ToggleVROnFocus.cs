using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ToggleVROnFocus : MonoBehaviour
{
    private bool hasFocus;
    List<XRDisplaySubsystemDescriptor> displays;
    XRDisplaySubsystem dispInst;

    private void Awake()
    {
        displays = new List<XRDisplaySubsystemDescriptor>();
        
    }
    void Update()
    {
        if (!Application.isFocused)
        {
            if (!hasFocus) return;
            StartCoroutine(SwitchOutOfVr());
            hasFocus = false;
            Debug.Log("Application lost focus");
        }
        else
        {
            if (hasFocus) return;
            StartCoroutine(SwitchToVR());
            hasFocus = true;
            Debug.Log("Application gained focus");
        }
    }

    IEnumerator SwitchToVR()
    {
        SubsystemManager.GetSubsystemDescriptors(displays);
        Debug.Log("Number of display providers found: " + displays.Count);
        foreach (var d in displays)
        {
            Debug.Log("Scanning display id: " + d.id);

            if (d.id.Contains("OpenXR Display"))
            {
                Debug.Log("Creating display " + d.id);
                dispInst = d.Create();
                if (dispInst != null)
                {
                    Debug.Log("Starting display ");
                    dispInst.Start();
                }
            }
        }
        
        // Wait one frame!
        yield return null;
    }

    IEnumerator SwitchOutOfVr()
    {
        if (dispInst != null)
        {
            Debug.Log("Stopping display ");
            dispInst.Stop();
        }

        // Wait one frame!
        yield return null;


    }
}
