using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class enemyMouvement : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Stats")]
    [SerializeField] float mouvementSpeed;
    private SpriteRenderer sprite;
    Vector3 direction;
    GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        playerRef = mouvementSCript.instance.gameObject;
    }

    private void Update()
    {
        if (direction.x < 0)
        {
            sprite.flipX = false;
        }
        else if (direction.x > 0)
        {
            sprite.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        direction = playerRef.transform.position - rb.transform.position;
        rb.velocity = direction.normalized * mouvementSpeed;
    }
}
