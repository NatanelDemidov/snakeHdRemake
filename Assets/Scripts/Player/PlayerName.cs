using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.AI;

public class PlayerName : NetworkBehaviour
{
    [SerializeField] TMP_Text playerNameText;
    [SyncVar(hook = nameof(HandlePlayerName))]
    string playerName;
    public string Name
    {
        get
        {
            return playerName;
        }
    }
    void HandlePlayerName(string oldText, string newText)
    {
        playerNameText.text = newText;
    }
    public override void OnStartServer()
    {
        playerName = $"Player {connectionToClient.connectionId}";
    }
}
