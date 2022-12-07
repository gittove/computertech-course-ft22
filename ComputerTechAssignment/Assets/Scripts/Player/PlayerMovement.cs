using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private Vector3 velocity;
    private Vector3 direction;

    Transform transform;

    private void Start()
    {
        transform = GetComponent<Transform>();
    }

    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        CalculateMove();
        Move();
    }

    private void CalculateMove()
    {
        Vector3 acceleration = Vector3.zero;

        acceleration.x = direction.x * movementSpeed * Time.deltaTime;
        acceleration.z = direction.z * movementSpeed * Time.deltaTime;

        velocity += transform.forward;
    }

    private void Move()
    {
        transform.localPosition += velocity;
    }
}
