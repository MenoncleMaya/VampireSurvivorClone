using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ennemyHealth : MonoBehaviour, IPooledObject
{
    [SerializeField] private const int MAX_HEALTH = 20;
    [SerializeField] private int currentHealth = 0;
    
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        currentHealth = MAX_HEALTH;
    }

    public void TakeDamage(int dammage)
    {
        currentHealth -= dammage;
        if (currentHealth <= 0) { Die(); }
    }

    private void Die()
    {
        SoundPlayer.GetInstance().PlayDeathSound();

        // Then destroy the game object
        Destroy(gameObject);
    }
}
