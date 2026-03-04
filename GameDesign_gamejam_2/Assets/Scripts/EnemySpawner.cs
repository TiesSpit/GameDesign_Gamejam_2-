using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private float spawnTimer;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTimer);
            Instantiate(enemyPrefab, transform.position, transform.rotation);
        }
    }
}
