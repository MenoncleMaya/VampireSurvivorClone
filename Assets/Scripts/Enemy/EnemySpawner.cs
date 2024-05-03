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
    //[SerializeField] GameObject ;
    #endregion

    [System.Serializable]

    public class Wave
    {
        public string[] tags;
    }

    [Header("Settings")]
    [SerializeField] private float spawnInterval;
    [SerializeField] private float currentTime;
    [SerializeField] private float spawnRange;
    //int randomEnemy;
    public List<Wave> waves = new List<Wave>();
    int currentWave = 0;


    private void Start()
    {
        //currentTime = spawnInterval;
        StartCoroutine(SpawnEnemy());
        //NextWave to do
    }

    public IEnumerator SpawnEnemy()
    {
        int j = 0;
        int amountToSpawn = waves[currentWave].tags.Length / 60;
        while (j < 60)
        {
            for (int i = 0 + amountToSpawn * j; i < amountToSpawn * 1 + j; i++) //change this to take out rng amount later?
            {
                GameObject temp = ObjectPooler.GetInstance().SpawnFromPool(waves[currentWave].tags.ElementAt(i), GenerateRandomPoint(spawnRange));
            }
            //randomEnemy = Random.Range(0, waves[wave].Length);

            j++;
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
