using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Wave[] waves;
    private void Awake()
    {
        instance = this;
    }

    private EnemyController[] enemies;
    public Transform closestEnemy;
    private void Update()
    {
        closestEnemy = GetEnemy(PlayerController.instance.transform);
    }
    public Transform GetEnemy(Transform item) //Finds closest enemy
    {
        enemies = FindObjectsOfType<EnemyController>();
        float closestDistance = Mathf.Infinity;
        Transform enemyTransform = null;
        foreach (EnemyController go in enemies)
        {
            float currentDistance;
            //currentDistance = Vector3.Distance(item.transform.position, go.transform.position);
            currentDistance = (go.transform.position - item.transform.position).sqrMagnitude;
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                enemyTransform = go.transform;
            }
        }
        Debug.DrawLine(item.transform.position, enemyTransform.position);
        return enemyTransform;
    }
}
