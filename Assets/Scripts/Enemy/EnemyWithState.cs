using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWithState : MonoBehaviour
{
    public float speed = 5.0f;
    public float shootingRange = 3.0f;
    Rigidbody2D rb;

    [SerializeField] ShootAtPlayer SAP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        MoveAndShoot();
    }

    void MoveAndShoot()
    {
        float distanceToTarget = Vector2.Distance(transform.position, mouvementSCript.GetInstance().gameObject.transform.position);

        // Move towards the target if outside of shooting range
        if (distanceToTarget > shootingRange)
        {
            Vector2 direction = (mouvementSCript.GetInstance().gameObject.transform.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
            SAP.inRange = false;
        }
        else
        {
            // Stop moving when within range
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SAP.inRange = true;
        }
    }
}
