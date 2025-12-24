using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
public class GameOverDisplay : NetworkBehaviour
{
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] GameObject canvas;
    
    void Start()
    {
        GameOverHandler.ClienOnGameOver += ClientHandleGameOver;
        if (isLocalPlayer)
        {
            canvas.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        GameOverHandler.ClienOnGameOver -= ClientHandleGameOver;
    }
    void ClientHandleGameOver(string winner)
    {
        canvas.SetActive(true);
        playerNameText.text = "The winner is "+winner;
    }
    public void RE4Rstartgame()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }
        canvas.SetActive(false);
    }
    
}
