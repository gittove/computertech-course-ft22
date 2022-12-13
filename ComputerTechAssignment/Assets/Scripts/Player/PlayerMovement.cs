using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector3 torque;
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

        float yawRotation = direction.x * rotationSpeed * Time.deltaTime;
        acceleration = transform.forward * (direction.y * movementSpeed * Time.deltaTime);
        acceleration += transform.right * (direction.x * movementSpeed * Time.deltaTime);

        torque += new Vector3(0.0f, yawRotation, 0.0f);
        velocity = acceleration;
    }

    private void Move()
    {
        //transform.localRotation = Quaternion.Euler(torque);
        transform.localPosition += velocity;
    }
}
