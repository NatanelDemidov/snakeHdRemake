using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;
public class Food : NetworkBehaviour
{
    [SerializeField] GameObject particlePrefab;
    public static event Action<GameObject> ServerOnFoodEaten;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        //FindObjectOfType<Snake>().AddTail();
        GameObject boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        Destroy(boom, 3f);
        NetworkServer.Destroy(gameObject);
        ServerOnFoodEaten?.Invoke(other.transform.gameObject);
    }
    public override void OnStopServer()
    {
        NetworkServer.Destroy(gameObject);
    }
}
