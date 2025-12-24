using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
public class GameOverHandler : NetworkBehaviour
{
    List<PlayerName> players = new List<PlayerName>();
    public static event Action<string> ClienOnGameOver; 
    [ClientRpc] 
    void RpcGameOver(string winner)
    {
        ClienOnGameOver?.Invoke(winner);
    }
    public override void OnStartServer()
    {
        PlayerSnake.OnServerPlayerSpawned += ServerHandlePlayerSpawn;
        PlayerSnake.OnServerPlayerDisSpawned += ServerHandlePlayerDispawn;
    }
    public override void OnStopServer()
    {
        PlayerSnake.OnServerPlayerSpawned -= ServerHandlePlayerSpawn;
        PlayerSnake.OnServerPlayerDisSpawned -= ServerHandlePlayerDispawn;
    }
    void ServerHandlePlayerSpawn(PlayerName pn)
    {
        players.Add(pn);
    }
    void ServerHandlePlayerDispawn(PlayerName pn)
    {
        players.Remove(pn);
        if(players.Count != 1)
        {
            return;
        }
        RpcGameOver(players[0].Name);
    }
}
