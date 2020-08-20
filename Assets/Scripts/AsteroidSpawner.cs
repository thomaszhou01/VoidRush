using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRange;
    public float spawnInterval;
    public Transform player;
    public Vector3 offset;


    private Vector3 spawnPoint;
    private Vector3 desiredPos;
    public GameObject asteroid;
    public float startSafeRange;
    private List<GameObject> objectsToPlace = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(asteroidWave());
    }

    // Update is called once per frame
    void Update()
    {
        desiredPos = player.position + offset;

    }

    public void spawnAsteroid()
    {
        GameObject asteroid_instance = Instantiate(asteroid, spawnPoint, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))) as GameObject;

    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            PickSpawnPoint();
            spawnAsteroid();
        }

    }

    public void PickSpawnPoint()
    {
        spawnPoint = new Vector3(Random.Range(-1f, 1f) * spawnRange + desiredPos.x, Random.Range(-1f, 1f) * spawnRange + desiredPos.y, desiredPos.z);
    }
}
