using UnityEngine;
using System.Collections.Generic;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject CubePrefab; // Assign your Cube prefab in the Inspector
    public int maxCubes = 3; // Maximum number of cubes to spawn
    public float minDistanceBetweenCubes = 1.0f;

    private List<Transform> availableSpawnPoints = new List<Transform>();
    private List<GameObject> cubes = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeSpawnPoints();
        SpawnObjects(maxCubes);
    }

    // Update is called once per frame
    void Update()
    {
        CheckAndRespawnCubes();
    }

    private void InitializeSpawnPoints()
    {
        availableSpawnPoints.Clear();

        foreach (GameObject spawnPoint in spawnPoints)
        {
            availableSpawnPoints.Add(spawnPoint.transform);
        }
    }

    private void SpawnObjects(int numToSpawn)
    {
        if (numToSpawn <= 0) return;

        for (int i = 0; i < numToSpawn && availableSpawnPoints.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            Transform spawnPoint = availableSpawnPoints[randomIndex];

            if (!IsCubeCloseToSpawnPoint(spawnPoint))
            {
                Vector3 spawnPosition = GetValidSpawnPosition(spawnPoint);
                GameObject cubeSpawned = Instantiate(CubePrefab, spawnPosition, Quaternion.identity);
                cubes.Add(cubeSpawned);
                availableSpawnPoints.RemoveAt(randomIndex);
            }
        }
    }

    private Vector3 GetValidSpawnPosition(Transform spawnPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, -Vector3.up, out hit))
        {
            return new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
        }
        return spawnPoint.position;
    }

    private bool IsCubeCloseToSpawnPoint(Transform spawnPoint)
    {
        foreach (var cube in cubes)
        {
            if (cube != null && Vector3.Distance(cube.transform.position, spawnPoint.position) < minDistanceBetweenCubes)
            {
                return true;
            }
        }
        return false;
    }

    private void CheckAndRespawnCubes()
    {
        cubes.RemoveAll(cube => cube == null);

        int cubesToSpawn = maxCubes - cubes.Count;
        if (cubesToSpawn > 0)
        {
            SpawnObjects(cubesToSpawn);
        }
    }
}