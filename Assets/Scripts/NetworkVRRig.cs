using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NetworkVRRig : VRRig
{
    private PhotonView photonView;

    // Start is called before the first frame update
    protected override void StartDerived()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    protected override bool CanMapTransform()
    {
        return photonView.IsMine;
    }
}
