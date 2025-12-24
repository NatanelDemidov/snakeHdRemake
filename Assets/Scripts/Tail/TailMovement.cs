using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class TailMovement : NetworkBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] TailNetwork tn;
    private void Start()
    {
        transform.position = tn.Target.transform.position;
    }
    private void Update()
    {
        agent.SetDestination(tn.Target.transform.position);
    }
}
