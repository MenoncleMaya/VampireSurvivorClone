using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    //Je ne l'utilise pas puisque jai un systeme de wave pre definie d'instaurer
    //De plus jai un pratiquement un equivalant que jutilise deja


    [SerializeField] string weakEnnemy;
    [SerializeField] string mediumEnnemy;
    [SerializeField] string strongEnnemy;

    private static EnemyFactory instance;
    public static EnemyFactory GetInstance() => instance;

    public void Awake()
    {
        instance = this;
    }

    public GameObject CreateWeakEnnemy()
    {
        return ObjectPooler.GetInstance().SpawnFromPool(weakEnnemy, Vector3.zero);
    }
    public GameObject CreateMediumEnnemy()
    {
        return ObjectPooler.GetInstance().SpawnFromPool(mediumEnnemy, Vector3.zero);
    }
    public GameObject CreateStrongEnnemy()
    {
        return ObjectPooler.GetInstance().SpawnFromPool(strongEnnemy, Vector3.zero);
    }
}
