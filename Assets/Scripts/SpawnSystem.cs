using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnObjects()
    {
        List<GameObject> tempSpawnPoints = new List<GameObject>();
        tempSpawnPoints.AddRange(spawnPoints);
        tempSpawnPoints.Shuffle();

        for (int i = 0; i < 3; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(tempSpawnPoints[i].transform.position, -Vector3.up, out hit))
            {
                Vector3 location = new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z);
                GameObject poolSpawned = Instantiate(Cube, location, transform.rotation);
            }
        }
    }
}
    public static class ListExtensions { 
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rnd = new System.Random();
        for (var i = 0; i < list.Count; i++)
            list.Swap(i, rnd.Next(i, list.Count));
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }
}

