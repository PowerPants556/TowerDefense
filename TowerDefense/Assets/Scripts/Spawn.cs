using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float countdown = 3f;
    [SerializeField] private float timeBetweenSpawnEnemy = 2f;

    private int waweNumber = 1;


    private void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1f, 5f);
        StartCoroutine(SpawnWawe());
    }

    private IEnumerator SpawnWawe()
    {
        yield return new WaitForSeconds(countdown);
        for (int i = 0; i < waweNumber; i++)
        {
            GameObject obj = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            obj.transform.parent = transform;
            yield return new WaitForSeconds(timeBetweenSpawnEnemy);
        }
        waweNumber++;
        StartCoroutine(SpawnWawe());
    }
}
