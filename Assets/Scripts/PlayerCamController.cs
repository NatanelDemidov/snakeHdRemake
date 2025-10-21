using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCamController : NetworkBehaviour
{
    [SerializeField] GameObject cam;
    public override void OnStartAuthority()
    {
        cam.SetActive(true);
    }
}
