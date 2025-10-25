using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Food : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    public static event Action ServerOnFoodEaten;
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        FindObjectOfType<Snake>().AddTail();
        GameObject boom = Instantiate
            (particlePrefab, transform.position, particlePrefab.transform.rotation);
        Destroy(boom, 3f);
        Destroy(gameObject);
        ServerOnFoodEaten?.Invoke();
    }
}
