using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    [SerializeField] private Transform snake;
    [SerializeField] private GameObject roadPrefab;

    private int roadMaxCount = 2;
    private float roadLength;
    private float spawnPosition;
    private List<GameObject> roads = new List<GameObject>();

    private void Start()
    {
        roadLength = roadPrefab.transform.Find("Board").localScale.z;
        for (int i = 0; i < roadMaxCount; i++)
        {
            SpawnRoad();
        }
    }

    private void Update()
    {
        if (snake.position.z - roadLength > spawnPosition - (2.2f * roadLength))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }

    private void SpawnRoad()
    {
        GameObject road = Instantiate(roadPrefab, transform.forward * spawnPosition, transform.rotation);
        roads.Add(road);
        spawnPosition += roadLength;
    }

    private void DeleteRoad()
    {
        Destroy(roads[0]);
        roads.RemoveAt(0);
    }
}
