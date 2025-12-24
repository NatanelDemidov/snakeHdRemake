using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMovement : NetworkBehaviour
{
    [SerializeField][SyncVar] float speed = 0.5f;
    [SerializeField] float rotationSpeed = 180f, speedChange = 0.5f;
    public float Speed { 
        get { return speed; }
        private set { speed = value; } 
    }
    void ServerHandleFoodEaten(GameObject playerWhoAte)
    {
        if (gameObject != playerWhoAte) return;
        Speed += speedChange;
    }
    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += ServerHandleFoodEaten;
    }
    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= ServerHandleFoodEaten;
    }
    [ClientCallback]
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
