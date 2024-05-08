using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    [HideInInspector] public int direction = 1;
    [HideInInspector] public int dammage;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private bool doesRotate;
    [SerializeField] private string TargetTag;
    [SerializeField] private GameObject children;

    //private void Awake()
    //{
    //    //children = gameObject.GetComponentInChildren<GameObject>();
    //    //Debug.Log(children);
    //    //Debug.Log(GetComponentInChildren<GameObject>());
    //}

    void FixedUpdate()
    {
        transform.position += transform.right * speed * direction;
        if (doesRotate)
        {
        children.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime * -direction);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == TargetTag)
        {
            Debug.Log(TargetTag);
            if(TargetTag != null)
            {
                if (TargetTag == "Ennemy")
                {
                    collision.GetComponent<enemyHealth>().TakeDamage(dammage);
                    gameObject.SetActive(false);
                }
                else if (TargetTag == "Player")
                {
                    PlayerManager.GetInstance().PlayerTakeDamage(dammage);
                    Debug.Log("playerHit");
                }
            }
        }
    }
}
