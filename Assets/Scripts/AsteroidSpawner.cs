using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRange;
    public float spawnInterval;
    public float impactRange;
    public Transform player;
    public Vector3 offset;
    public GameObject asteroid;

    [Space(10)]
    public AsteroidSpawner SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public float difficultyIncreaseTime;
    public bool shouldExpand = false;


    private Vector3 spawnPoint;
    private Vector3 desiredPos;
    private Vector3 targetPos;

    // Start is called before the first frame update
    void Start()
    {

        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }


        StartCoroutine(asteroidWave());
        StartCoroutine(IncreaseDifficulty());
    }

    void Awake()
    {
        SharedInstance = this;
    }


    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        if (shouldExpand)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }

    IEnumerator IncreaseDifficulty()
    {
        while (spawnInterval - 0.05f > 0)
        {
            yield return new WaitForSeconds(difficultyIncreaseTime);
            spawnInterval -= 0.05f;
        }
        if(spawnInterval - 0.05f < 0)
        {
            StartCoroutine(IncreaseAsteroidCount());
        }
    }

    IEnumerator IncreaseAsteroidCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(difficultyIncreaseTime);
            shouldExpand = !shouldExpand;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredPos = player.position + offset;
    }


    public void spawnAsteroid()
    {

        GameObject asteroid_instance = SharedInstance.GetPooledObject();
        if (asteroid_instance != null)
        {
            PickSpawnPoint();
            asteroid_instance.transform.position = spawnPoint;
            asteroid_instance.SetActive(true);
            asteroid_instance.GetComponent<Rigidbody>().AddForce(targetPos * Random.Range(100000.0f, 200000.0f));
        }


    }

    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            spawnAsteroid();
        }

    }

    public void PickSpawnPoint()
    {
        spawnPoint = new Vector3(Random.Range(-1f, 1f) * spawnRange + desiredPos.x, Random.Range(-1f, 1f) * spawnRange + desiredPos.y, desiredPos.z);
        targetPos = (new Vector3(
            player.position.x + Random.Range(-impactRange, impactRange),
            player.position.y + Random.Range(-impactRange, impactRange),
            player.position.z + +Random.Range(-impactRange, impactRange) - 600) - spawnPoint).normalized;
    }
}
