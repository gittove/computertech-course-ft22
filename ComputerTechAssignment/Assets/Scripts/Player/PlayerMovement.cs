using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;

    private bool bRightMouseIsClicked;

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

        bRightMouseIsClicked = Input.GetMouseButton(1);

        CalculateMove();
        CalculateRotation();
        Move();


        // well, because i'm not a monster.
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void CalculateMove()
    {
        Vector3 acceleration = Vector3.zero;

        //float yawRotation = direction.x * rotationSpeed * Time.deltaTime;
        acceleration = transform.forward * (direction.y * movementSpeed * Time.deltaTime);
        acceleration += transform.right * (direction.x * movementSpeed * Time.deltaTime);

        //torque += new Vector3(0.0f, yawRotation, 0.0f);
        velocity = acceleration;
    }

    private void CalculateRotation()
    {
        if (!bRightMouseIsClicked)
        {
            return;
        }

        float pitchInput = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        float yawInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

        Vector3 newRot = new Vector3(pitchInput, yawInput, 0.0f) + transform.localRotation.eulerAngles;

        torque = newRot;
    }

    private void Move()
    {
        transform.localRotation = Quaternion.Euler(torque);
        transform.localPosition += velocity;
    }
}
