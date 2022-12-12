using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Offset (metres) in front of player, originating from the player's position")]
    [SerializeField] private int forwardOffset = 30;
    [SerializeField] private int upOffset = 15;

    [Header("Radius (metres) from centre of object in all axis directions")]
    [SerializeField] private int spawnRadiusMetres = 15;
    [SerializeField] private int SpawnIntervalInSeconds = 2;
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private GameObject player;

    private float spawnTimer = 0.0f;
    private Vector3 spawnPosition;
    private Bounds SpawnArea;
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

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= SpawnIntervalInSeconds)
        {
            SpawnAsteroid();
            spawnTimer = 0.0f;
        }
    }
    void FollowPlayer()
    {
        Vector3 newPosition = Vector3.zero;

        newPosition = playerTransform.position;
        newPosition += playerTransform.forward * this.forwardOffset;
        newPosition.y += upOffset;

        transform.position = newPosition;
    }

    void SpawnAsteroid()
    {
        GetRandomPositionInSpawnRadius();

        Instantiate(asteroidPrefabs[0]);
        // TODO instantiate asteroid
        // TODO convert asteroid to entity
    }

    void GetRandomPositionInSpawnRadius()
    {
        spawnPosition.x = Random.Range(transform.position.x - spawnRadiusMetres, transform.position.x + spawnRadiusMetres);
        spawnPosition.y = transform.position.y;
        spawnPosition.z = Random.Range(transform.position.z - spawnRadiusMetres, transform.position.z + spawnRadiusMetres);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = new Color(1.0f, 0.0f, 0.0f);
    //    Gizmos.DrawWireCube(this.transform.position, new Vector3(spawnRadiusMetres, 1.0f, spawnRadiusMetres));
    //}
}
