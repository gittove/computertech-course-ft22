using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Offset (metres) in front of player, originating from the player's position")]
    [SerializeField] private int forwardOffset = 30;
    [SerializeField] private int upOffset = 15;

    [SerializeField] private GameObject player;

    private Transform transform;
    private Transform playerTransform;

    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = player.GetComponent<Transform>();
    }

    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        Vector3 newPosition = Vector3.zero;

        newPosition = playerTransform.position;
        newPosition += playerTransform.forward * this.forwardOffset;
        newPosition.y += upOffset;

        transform.position = newPosition;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
    //    Gizmos.DrawWireCube(this.transform.position, new Vector3(spawnRadiusMetres, 1.0f, spawnRadiusMetres));
    //}
}
