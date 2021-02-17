using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HeadTransformMapper : MonoBehaviour
{
    private Camera camera;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camera.transform.position;
            transform.rotation = camera.transform.rotation;
    }
}
