using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public float spawnRange;
    public float spawnInterval;
    public Transform player;
    public Vector3 offset;
    public GameObject asteroid;
    public float startSafeRange;

    [Space(10)]
    public AsteroidSpawner SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private Vector3 spawnPoint;
    private Vector3 desiredPos;

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
        return null;
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
            asteroid_instance.GetComponent<Rigidbody>().AddForce((new Vector3(player.position.x, player.position.y, player.position.z + 0) - spawnPoint).normalized * Random.Range(100000.0f, 200000.0f));
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
    }
}
