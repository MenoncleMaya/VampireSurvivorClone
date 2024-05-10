using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class XpOrbs : MonoBehaviour
{
    [SerializeField] private float strength; // How fast the object moves towards the target
    [SerializeField] private float range; // The maximum range of effect
    [SerializeField] int xpAmount;
    GameObject playerRef;

    public Collider2D[] hits;

    private Rigidbody2D rb;



    public float detectionRadius = 5.0f; // Radius within which to check for other objects
    public string objectTag; // Tag to identify the type of object
    public string nextObjectTag; // Tag to identify the type of object
    public int requiredCount = 4; // The number of objects needed
    public List<GameObject> orbs;

    //void Update()
    //{
    //    if (objectTag != "largeXpOrb")
    //    {
    //        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
    //        int count = 0;

    //        foreach (Collider2D hit in hits)
    //        {
    //            if (hit.gameObject.tag == objectTag && hit.gameObject != gameObject)
    //            {
    //                count++;
    //            }
    //        }

    //        if (count >= requiredCount)
    //        {
    //            foreach (Collider2D hit in hits)
    //            {
    //                if (hit.gameObject.tag == objectTag && hit.gameObject != gameObject)
    //                {
    //                    hit.gameObject.SetActive(false);
    //                }
    //            }
    //            ObjectPooler.GetInstance().SpawnFromPool(nextObjectTag, this.gameObject.transform.position);

    //            gameObject.SetActive(false);
    //            Debug.Log("There are at least " + requiredCount + " objects of type " + objectTag + " nearby.");
    //        }
    //    }
    //}



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRef = mouvementSCript.instance.gameObject;
    }

    void FixedUpdate()
    {
        if (playerRef != null && rb != null)
        {
            Vector3 direction = playerRef.transform.position - transform.position;
            float distance = direction.magnitude;

            if (distance <= range)
            {
                direction = playerRef.transform.position - rb.transform.position;
                rb.velocity = direction.normalized * strength;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.GetInstance().AddXp(xpAmount);
            gameObject.SetActive(false);
        }
    }

    public void CheckForOrbs()
    {
        if (objectTag != "largeXpOrb")
        {
            hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
            int count = 0;

            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.tag == objectTag && hit.gameObject != gameObject)
                {
                    count++;
                    orbs.Add(hit.gameObject);
                    hit.gameObject.GetComponent<XpOrbs>().UpdateOrbs(this.gameObject);
                }
            }

            if (count >= requiredCount)
            {
                foreach (Collider2D hit in hits)
                {
                    if (hit.gameObject.tag == objectTag && hit.gameObject != gameObject)
                    {
                        orbs.Remove(hit.gameObject);
                        hit.gameObject.SetActive(false);
                    }
                }
                ObjectPooler.GetInstance().SpawnFromPool(nextObjectTag, this.gameObject.transform.position);

                gameObject.SetActive(false);
                Debug.Log("There are at least " + requiredCount + " objects of type " + objectTag + " nearby.");
            }
        }
    }

    public void UpdateOrbs(GameObject orb)
    {
        orbs.Add(orb);
        int tempCount = 0;
        foreach (GameObject o in orbs)
        {
            if (o.activeInHierarchy)
            {
                tempCount++;
            }
            else
            {
                orbs.Remove(o);
            }
        }
        if (tempCount  == 5)
        {
            foreach(GameObject o in orbs)
            {
                orbs.Remove(o);
                o.SetActive(false);
            }
            ObjectPooler.GetInstance().SpawnFromPool(nextObjectTag, this.gameObject.transform.position);
            gameObject.SetActive(false);
        }
    }


}
