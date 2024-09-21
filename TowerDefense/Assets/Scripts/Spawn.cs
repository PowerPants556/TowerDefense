using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 5f);
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform);
    }
}
