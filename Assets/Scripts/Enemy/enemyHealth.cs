using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyHealth : MonoBehaviour, IPooledObject
{
    [SerializeField] private const int MAX_HEALTH = 20;
    [SerializeField] private int currentHealth = 0;
    [SerializeField] private SpriteRenderer sr;
    
    // Start is called before the first frame update
    public void OnObjectSpawn()
    {
        currentHealth = MAX_HEALTH;
    }

    public void TakeDamage(int dammage)
    {
        currentHealth -= dammage;
        if (currentHealth <= 0) { Die(); } else { StartCoroutine(DammageFlashing()); }
    }

    private void Die()
    {
        SoundPlayer.GetInstance().PlayDeathSound();

        GameObject temp = ObjectPooler.GetInstance().SpawnFromPool("SmallXpOrb", this.gameObject.transform.position);
        
        gameObject.SetActive(false);
    }

    IEnumerator DammageFlashing()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }
}
