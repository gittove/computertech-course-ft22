using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    private Vector3 torque;
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

        float yawRotation = direction.x * movementSpeed * Time.deltaTime;
        //acceleration.z = direction.z * movementSpeed * Time.deltaTime;

        torque += new Vector3(0.0f, yawRotation, 0.0f);
    }

    private void Move()
    {
        transform.localRotation = Quaternion.Euler(torque);
    }
}
