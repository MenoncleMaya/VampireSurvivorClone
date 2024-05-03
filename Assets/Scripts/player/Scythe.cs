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
    [SerializeField] private GameObject children;

    private void Awake()
    {
        //children = gameObject.GetComponentInChildren<GameObject>();
        //Debug.Log(children);
        //Debug.Log(GetComponentInChildren<GameObject>());
    }

    void FixedUpdate()
    {
        transform.position += transform.right * speed * direction;
        children.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * -direction);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ennemy")
        {
            collision.GetComponent<enemyHealth>().TakeDamage(dammage);
            gameObject.SetActive(false);
        }
    }
}
