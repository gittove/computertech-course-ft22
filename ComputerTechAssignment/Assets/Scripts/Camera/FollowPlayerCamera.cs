using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private float followSpeed;
    [SerializeField] private float lookSpeed;
    [SerializeField] private float lookClampAngle = 80;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private Vector3 cameraPositionOffset;

    private float cameraPitchVelocity;
    private float cameraYawVelocity;

    private Transform transform;
    private Transform playerTransform;
    private bool bRightMouseIsClicked;
    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = playerObject.GetComponent<Transform>();
    }

    void Update()
    {
        bRightMouseIsClicked = Input.GetMouseButton(1);

        LookAround();
        LerpToNewPosition();
    }

    void LerpToNewPosition()
    {
        Vector3 yOffset = playerTransform.up * cameraPositionOffset.y;
        Vector3 zOffset = playerTransform.forward * cameraPositionOffset.z;
        Vector3 targetPosition = playerTransform.position + zOffset + yOffset;
        transform.localPosition = targetPosition; // Vector3.Lerp(transform.localPosition, targetPosition, followSpeed);
    }

    void LookAround()
    {
        if (bRightMouseIsClicked)
        {
            return;
        }

        cameraPitchVelocity = -Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;
        cameraYawVelocity = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;

        Vector3 newRot = new Vector3(cameraPitchVelocity, cameraYawVelocity, 0.0f) + transform.localRotation.eulerAngles;

        float minClamp = 360.0f - lookClampAngle;
        float maxClamp = lookClampAngle;

        //if (newRot.x >= maxClamp && newRot.x <= minClamp)
        //{
        //    newRot.x = newRot.x - maxClamp < Mathf.Abs(newRot.x - minClamp) ? maxClamp : minClamp;
        //}

        //if (newRot.y >= maxClamp && newRot.y <= minClamp)
        //{
        //    newRot.y = newRot.y - maxClamp < Mathf.Abs(newRot.y - minClamp) ? maxClamp : minClamp;
        //}

        transform.localRotation = Quaternion.Euler(newRot);
    }

    void RotateAround()
    {
        if (!bRightMouseIsClicked)
        {
            return;
        }


    }
}
