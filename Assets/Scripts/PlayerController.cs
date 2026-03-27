using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public float moveSpeed = 5f;

    private Vector2 move;
    void Start()
    {
        moveAction.Enable();
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        move = moveAction.ReadValue<Vector2>() * moveSpeed;
        transform.Translate(new Vector3(move.x, 0, move.y) * Time.fixedDeltaTime);
    }
}
