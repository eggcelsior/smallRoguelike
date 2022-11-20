using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private float spawnRadius = 9;
    public float time = 1.5f;

    public GameObject[] enemies;
    public int whatWave; //Determines what wave we're on to select the next one
    public Wave wave;
    private Wave nextWave;
    private float timer;
    public void NewWave()
    {
        wave = LevelManager.instance.waves[whatWave];
        nextWave = LevelManager.instance.waves[whatWave + 1];
        timer = nextWave.startTimeInSeconds;
        //Debug.Log(nextWave.startTimeInSeconds);
        spawnRadius = wave.spawnRadius;
        time = wave.time;
        enemies = wave.enemiesToSpawn;
    }

    private void Start()
    {
        whatWave = 0;
        NewWave();
        StartCoroutine(SpawnEnemy());
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            Debug.Log("Starting Next Wave");
            whatWave++;
            NewWave();
        }
    }

    IEnumerator SpawnEnemy()
    {
        Vector2 spawnPos = PlayerController.instance.transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnEnemy());
    }
}
