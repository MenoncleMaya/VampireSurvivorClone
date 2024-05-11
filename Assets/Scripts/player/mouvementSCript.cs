using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvementSCript : MonoBehaviour
{
    private static mouvementSCript instance;
    public static mouvementSCript GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<mouvementSCript>(); // Or find an existing manager in the scene
        }
        return instance;
    }


    [Header("Mouvement Var")]
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    public bool flipX;

    private float x, y;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GetInstance().GetIsPaused())
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }

        if(x < 0)
        {
            flipX = true;
        }
        else if(x > 0)
        {
            flipX = false;
        }
        sprite.flipX = flipX;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UiManager.GetInstance().TogglePauseMenu();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(x, y).normalized * moveSpeed;
    }
}
