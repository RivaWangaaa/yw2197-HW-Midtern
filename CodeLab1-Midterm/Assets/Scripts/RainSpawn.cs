using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawn : MonoBehaviour
{
    public GameObject spawnRain;

    public float maxTime = 6;

    public float minTime = 3;

    private float timer;

    private float spawnTime;

    private GameObject currentRain = null;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer == spawnTime)
        {
            SpawnObject();
            SetRandomTime();
            currentRain = null;
        }
    }

    void SpawnObject()
    {
        if (ASCIILoader.currentPlayer != null)
        {
            Vector3 rainPosition = new Vector3(Random.Range(-5,5), 10, 0);
            if (currentRain == null)
            {
                currentRain = Instantiate(spawnRain, rainPosition, spawnRain.transform.rotation);
            }
        }

        timer = 0;
    }

    void SetRandomTime()
    {
        spawnTime = (int)Random.Range(minTime, maxTime);
        print(spawnTime);
    }
}