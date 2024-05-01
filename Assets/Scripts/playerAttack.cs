using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int atkDamage;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float atkTimer;
    [SerializeField] private bool canAtk;
    [SerializeField] private GameObject weapon;
    [SerializeField] private const float ATK_TIMER = 1f;
    [SerializeField] private int direction;
    private SpriteRenderer sr;
    private Vector3 weaponPOS;



    private void Start()
    {
        atkTimer = ATK_TIMER;
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (sr.flipX)
        {
            direction = -1;
        }
        else { direction = 1; };

        weaponPOS = new Vector3(transform.position.x + 0.5f * direction, transform.position.y + 0.6f, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (canAtk)
        {
            atkTimer = ATK_TIMER;
            canAtk = false;
            CreateAtk(direction, weaponPOS, sr, atkDamage);
        }
        else
        {
            atkTimer -= Time.fixedDeltaTime * atkSpeed;
            if (atkTimer <= 0) { canAtk = true; }
        }
    }

    void CreateAtk(int direction, Vector3 weaponPOS, SpriteRenderer sr, float atkDammage)
    {
        GameObject temp = Instantiate(weapon, weaponPOS, Quaternion.identity);
        temp.GetComponentInChildren<SpriteRenderer>().flipX = sr.flipX;
        temp.GetComponent<Scythe>().direction = direction;
        temp.GetComponent<Scythe>().dammage = atkDamage;
        
        Destroy(temp, 0.75f);
    }
}


