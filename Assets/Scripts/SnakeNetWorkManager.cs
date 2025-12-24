using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SnakeNetWorkManager : NetworkManager
{
    [SerializeField] GameObject foodSpawnerPrefab;
    [SerializeField] GameObject gameOver;
    GameObject foodSpawner;
    public override void OnStartServer()
    {
        NetworkServer.Spawn(Instantiate(gameOver));
    }
    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        if(numPlayers != 2)
        {
            return;
        }
        foodSpawner = Instantiate(foodSpawnerPrefab);
        NetworkServer.Spawn(foodSpawner);
    }
    public override void OnStopServer()
    {
        NetworkServer.Destroy(foodSpawner);
    }
}
