using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetWorkManager : NetworkManager
{
    [SerializeField] GameObject foodSpawnerPrefab;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        if(numPlayers != 2)
        {
            return;
        }
        GameObject foodSpawner = Instantiate(foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawner);
    }
}
