using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab;
    [SerializeField]private const float spawnTime = 6.0f;
    [SerializeField]private const int maxEnemy = 10;
    [SerializeField]private float time;
    [SerializeField]private int enemyCount;

    public int EnemyCount { get => enemyCount; set => enemyCount = value; }


    private void OnEnable()
    {
        Pile.OnUnstackEnemy+= UpdateCount;
    }
    void Start()
    {
        enemyCount = 0;
        time = spawnTime;
        SpawnEnemy();
    }

    void FixedUpdate()
    {
        if (enemyCount >= maxEnemy)
            return;
        
        time-= Time.fixedDeltaTime;

        if (time <= 0)
        {
            time = spawnTime;
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        enemyCount+=1;
        Instantiate(enemyPrefab, RandomLocal(), Quaternion.identity);
    }

    Vector3 RandomLocal(){
        float offsetX = -5;
        return new Vector3(Random.Range(-22f,22f) + offsetX, 0, Random.Range(-31f,31f));
    }

    void UpdateCount(){
        enemyCount-=1;
    }


    private void OnDisable()
    {
        Pile.OnUnstackEnemy-= UpdateCount;
    }
}
