using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axes : MonoBehaviour
{
    public Transform centralObject;
    public float orbitSpeed = 50.0f;
    public float orbitRadius = 2.0f;
    public GameObject[] orbiters = new GameObject[3];


    private float[] angles = new float[3];

    void Awake()
    {
        // Initialize angles for each orbiter
        for (int i = 0; i < orbiters.Length; i++)
        {
            // Set initial angle based on spacing
            angles[i] = i * 120; // Spreads them evenly 120 degrees apart
        }

        UiManager.GetInstance().LvUpAxeEvent += LvUpAxeHere;
    }

    void Update()
    {
        if (centralObject != null)
        {
            for (int i = 0; i < orbiters.Length; i++)
            {
                angles[i] += orbitSpeed * Time.deltaTime;
                float x = Mathf.Cos(angles[i] * Mathf.Deg2Rad) * orbitRadius;
                float y = Mathf.Sin(angles[i] * Mathf.Deg2Rad) * orbitRadius;
                if (orbiters[i] != null)
                {
                    Vector3 orbitPosition = new Vector3(x, y, 0) + centralObject.position;
                    orbiters[i].transform.position = orbitPosition;
                    // Make the orbiter face the central object
                    orbiters[i].transform.right = (centralObject.position - orbiters[i].transform.position).normalized;
                }
            }
        }
    }

    private void LvUpAxeHere()
    {
        switch (PlayerManager.GetInstance().axeLv)
        {
            case 1:
                orbiters[0].gameObject.SetActive(true);
                break;
            case 2:
                orbiters[1].gameObject.SetActive(true);
                break;
            case 3:
                orbiters[2].gameObject.SetActive(true);
                break;
        }
    }
}
