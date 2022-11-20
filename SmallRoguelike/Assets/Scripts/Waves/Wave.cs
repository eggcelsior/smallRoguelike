using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Wave : ScriptableObject
{
    public GameObject[] enemiesToSpawn;
    public float spawnRadius;
    public float time;
    public float startTimeInSeconds; //when should this wave start
}
