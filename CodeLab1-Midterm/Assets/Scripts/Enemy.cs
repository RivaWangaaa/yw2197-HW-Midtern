using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject spawnEnemy;

    public float maxTime = 6;

    public float minTime = 2;

    private float timer;

    private float spawnTime;

    private GameObject currentEnemy = null;
    
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
            currentEnemy = null;
        }
    }

    void SpawnObject()
    {
        if (ASCIILoader.currentPlayer != null)
        {
            Vector3 enemyPositioin = new Vector3(10, ASCIILoader.currentPlayer.transform.position.y, 0);
            if (currentEnemy == null)
            {
                currentEnemy = Instantiate(spawnEnemy, enemyPositioin, spawnEnemy.transform.rotation);
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
