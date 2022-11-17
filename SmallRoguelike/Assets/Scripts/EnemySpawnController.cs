using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private float spawnRadius = 9;
    public float time = 1.5f;

    public GameObject[] enemies;
    private int whatWave = 0; //Determines what wave we're on to select the next one
    public Wave wave;

    public void NewWave()
    {
        wave = LevelManager.instance.waves[whatWave];
        spawnRadius = wave.spawnRadius;
        time = wave.time;
        enemies = wave.enemiesToSpawn;
    }

    private void Start()
    {
        NewWave();
        StartCoroutine(SpawnEnemy());
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
