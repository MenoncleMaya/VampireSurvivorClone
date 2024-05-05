using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region EnemyPrefab
    [Header("Enemys")]
    [SerializeField] string merman;
    [SerializeField] string squeleton;
    [SerializeField] string bat;
    //[SerializeField] GameObject ;
    #endregion

    [System.Serializable]

    public class Wave
    {
        public string[] tags;
        public int enemyAmount;
    }

    [Header("Settings")]
    [SerializeField] private float spawnRange;
    public List<Wave> waves = new List<Wave>();
    public Wave lastWave = new Wave();
    int currentWave = -1;

    private static EnemySpawner instance;
    public static EnemySpawner GetInstance() => instance;

    private void Start()
    {
        instance = this;
    }

    private IEnumerator SpawnEnemy()
    {
        int j = 0;
        int amountToSpawn = waves[currentWave].enemyAmount / 60;
        while (j < 60)
        {
            for (int i = 0; i < amountToSpawn; i++)
            {
                ObjectPooler.GetInstance().SpawnFromPool(waves[currentWave].tags.ElementAt(UnityEngine.Random.Range(0, waves[currentWave].tags.Length)), GenerateRandomPoint(spawnRange));
            }

            j++;
            yield return new WaitForSeconds(1f);
        }

    }
    public void WaveStarter()
    {
        if (currentWave < waves.Count - 1)
        {
            currentWave++;
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            StartCoroutine(SpawnEnemyInfinity());
        }
    }

    private IEnumerator SpawnEnemyInfinity()
    {
        int amountToSpawn = lastWave.tags.Length / 60;
        int j = 0;
        while (true)
        {
            for (int i = 0; i < amountToSpawn + j / 2; i++)
            {
                ObjectPooler.GetInstance().SpawnFromPool(lastWave.tags.ElementAt(UnityEngine.Random.Range(0, lastWave.tags.Length)), GenerateRandomPoint(spawnRange));
            }
            j++;
            //randomEnemy = Random.Range(0, waves[wave].Length);
            yield return new WaitForSeconds(1f);
        }

    }

    public Vector3 GenerateRandomPoint(float distance)
    {
        // Generate a random angle between 0 and 2π radians
        float angle = UnityEngine.Random.Range(0f, 2 * Mathf.PI);

        // Convert polar coordinates (angle, distance) to Cartesian coordinates (x, y)
        float x = this.transform.position.x + distance * Mathf.Cos(angle);
        float y = this.transform.position.y + distance * Mathf.Sin(angle);

        return new Vector3(x, y, 0f);
    }

}
