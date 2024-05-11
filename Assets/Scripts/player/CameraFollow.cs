using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollow : MonoBehaviour
{
    Vector3 target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = mouvementSCript.GetInstance().gameObject.transform.position + offset;
        Vector3 position = Vector3.Lerp(rb.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        rb.MovePosition(position);
    }
}
