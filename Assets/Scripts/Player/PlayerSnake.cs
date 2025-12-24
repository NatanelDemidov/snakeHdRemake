using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.VisualScripting;
using System;
public class PlayerSnake : NetworkBehaviour
{
    [SerializeField] TailSpawner ts;
    public static event Action<PlayerName> OnServerPlayerSpawned;
    public static event Action<PlayerName> OnServerPlayerDisSpawned;
    [SerializeField] PlayerName pn;

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out NetworkIdentity netWorkIdentity) && netWorkIdentity.connectionToClient == connectionToClient) return;
        switch (other.tag)
        {
            case "Border":
                DestroySelf();
                break;
            case "Player":
                DestroySelf();
                break;
            case "Tail":
                DestroySelf();
                break;
        }
            
    }
    void DestroySelf()
    {
        OnServerPlayerDisSpawned?.Invoke(pn);
        foreach (GameObject tail in ts.Tails)
        {
            NetworkServer.Destroy(tail);      
        }
        NetworkServer.Destroy(gameObject);
        
    }
    public override void OnStartServer()
    {
        OnServerPlayerSpawned?.Invoke(pn);
    }
}
