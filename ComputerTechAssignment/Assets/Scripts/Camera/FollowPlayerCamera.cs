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

    private new Transform transform;
    private Transform playerTransform;

    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = playerObject.GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 yOffset = playerTransform.up * cameraPositionOffset.y;
        Vector3 zOffset = playerTransform.forward * cameraPositionOffset.z;
        Vector3 targetPosition = playerTransform.position + zOffset + yOffset;
        transform.localPosition = targetPosition;

        Quaternion playerRotation = playerTransform.rotation;
        transform.localRotation = Quaternion.Lerp(transform.localRotation, playerTransform.localRotation, 0.5f);
    }
}
