using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] enemyPrefabs;
    [SerializeField] private float spawnTimer;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);

            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Enemy randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            Instantiate(randomEnemy, spawnPos, randomEnemy.transform.rotation, transform);
            Debug.Log(randomEnemy + "  " + transform.position);
        }
    }
}
