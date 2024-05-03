using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region EnemyPrefab
    [Header("Enemys")]
    [SerializeField] string merman;
    [SerializeField] string squeleton;
    //[SerializeField] GameObject ;
    #endregion

    [Header("Settings")]
    [SerializeField] private float spawnInterval;
    [SerializeField] private float currentTime;
    [SerializeField] private float spawnRange;
    int randomEnemy;
    List<string[]> waves;
    int currentWaves = 1;


    private void Start()
    {
        currentTime = spawnInterval;
    }

    private void FixedUpdate()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = spawnInterval;
            //ObjectPooler.GetInstance().SpawnFromPool(merman, GenerateRandomPoint(spawnRange));
        }
    }

    public IEnumerator SpawnEnemy(int wave)
    {
        while (true)
        {
            for (int i = 0; i < waves[wave].Length; i++) //change this to take out rng amount later?
            {
                ObjectPooler.GetInstance().SpawnFromPool(merman, GenerateRandomPoint(spawnRange));
            }
            randomEnemy = Random.Range(0, waves[wave].Length);


            yield return new WaitForSeconds(spawnInterval);
        }

    }

    public Vector3 GenerateRandomPoint(float distance)
    {
        // Generate a random angle between 0 and 2π radians
        float angle = Random.Range(0f, 2 * Mathf.PI);

        // Convert polar coordinates (angle, distance) to Cartesian coordinates (x, y)
        float x = this.transform.position.x + distance * Mathf.Cos(angle);
        float y = this.transform.position.y + distance * Mathf.Sin(angle);

        return new Vector3(x, y, 0f);
    }

}
