using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TailNetwork : NetworkBehaviour
{
    [SyncVar] SnakeMovement owner;
    [SyncVar] GameObject target;
    
    public SnakeMovement Owner 
    { 
        get {  return owner; }
        private set { owner = value; }
    }
    public GameObject Target
    {
        get { return target; }
        private set { target = value; }

    }
    public override void OnStartServer()
    {
        Owner = connectionToClient.identity.GetComponent<SnakeMovement>();
        List<GameObject> tails = Owner.GetComponent<TailSpawner>().Tails;
        if(tails.Count > 0)
        {
            Target = tails[tails.Count - 1];
        }
        else
        {
            Target = Owner.gameObject;
           
        }
        tails.Add(gameObject);
    }
}
