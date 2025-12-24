using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class FoodSpawner : NetworkBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] float xSize = 8f, zSize = 8f;

    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += SpawnFood;
        SpawnFood(gameObject);
    }
    [Server]
    public void SpawnFood(GameObject playerWhoAte)
    {
        Vector3 pos = new Vector3(
            Random.Range(-xSize, xSize),
            foodPrefab.transform.position.y,
            Random.Range(-zSize, zSize));
        GameObject apple = Instantiate(foodPrefab, pos, foodPrefab.transform.rotation);
        NetworkServer.Spawn(apple);
    }
    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= SpawnFood;
    }
}
