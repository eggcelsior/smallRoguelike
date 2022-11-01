using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
    }

    private GameObject[] enemies;
    public Transform closestEnemy;
    public Transform GetEnemy(Transform item) //Finds closest enemy
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        float closestDistance = Mathf.Infinity;
        Transform enemyTransform = null;
        foreach (GameObject go in enemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(item.transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                enemyTransform = go.transform;
            }
        }
        return enemyTransform;
    }
}
