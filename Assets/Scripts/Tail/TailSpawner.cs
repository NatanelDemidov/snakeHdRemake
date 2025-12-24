using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailSpawner : NetworkBehaviour
{
    [SerializeField] GameObject tailPrefab;
    public List<GameObject> Tails { get; } = new List<GameObject>();

    public override void OnStartServer()
    {
        base.OnStartServer();
        Food.ServerOnFoodEaten += AddTail;
    }
    void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte == gameObject)
        {
            GameObject tailInstance = Instantiate(tailPrefab);
            NetworkServer.Spawn(tailInstance,connectionToClient);
        }
        
    }
    public override void OnStopServer()
    {
        base.OnStopServer();
        Food.ServerOnFoodEaten -= AddTail;
    }
}
