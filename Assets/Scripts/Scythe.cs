using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [HideInInspector] public int direction;
    [HideInInspector] public int dammage;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private const string ENNEMY = "Ennemy";

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * speed * direction;
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * -direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ennemy")
        {
            collision.GetComponent<ennemyHealth>().TakeDamage(dammage);
            Destroy(gameObject);
        }
    }
}
