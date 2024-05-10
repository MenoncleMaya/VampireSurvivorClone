using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int Lv1AtkDammage;
    [SerializeField] private int Lv2AtkDammage;
    [SerializeField] private int Lv3AtkDammage;
    [SerializeField] private float atkSpeed;
    [SerializeField] private float atkTimer;
    [SerializeField] private bool canAtk;
    [SerializeField] private const float ATK_TIMER = 1f;
    [SerializeField] private int direction;
    [SerializeField] private int atkLv;
    private SpriteRenderer sr;
    private float rotTop = 30f;
    private float rotBot = 330f;
    private bool playerIsAlive;



    private void Awake()
    {
        atkTimer = ATK_TIMER;
        sr = GetComponentInChildren<SpriteRenderer>();
        PlayerManager.GetInstance().PlayerIsDead += playersDeath;
        playerIsAlive = true;
    }

    private void Update()
    {
        if (sr.flipX)
        {
            direction = -1;
        }
        else { direction = 1; };
    }

    private void FixedUpdate()
    {
        if(playerIsAlive)
        if (canAtk)
        {
            atkTimer = ATK_TIMER;
            canAtk = false;
            AtkWithLv();
        }
        else
        {
            atkTimer -= Time.fixedDeltaTime * atkSpeed;
            if (atkTimer <= 0) { canAtk = true; }
        }
    }

    void AtkWithLv()
    {
        switch (atkLv)
        {
            case 1:
                CreateAtk(direction, new Vector3(transform.position.x + 0.5f * direction, transform.position.y + 0.6f, transform.position.z), sr, Lv1AtkDammage, 0f);
                break;
            case 2:
                CreateAtk(direction, new Vector3(transform.position.x + 0.4f * direction, transform.position.y + 0.7f, transform.position.z), sr, Lv2AtkDammage, rotTop);
                CreateAtk(direction, new Vector3(transform.position.x + 0.4f * direction, transform.position.y + 0.5f, transform.position.z), sr, Lv2AtkDammage, rotBot);
                break;
            case 3:
                CreateAtk(direction, new Vector3(transform.position.x + 0.4f * direction, transform.position.y + 0.7f, transform.position.z), sr, Lv3AtkDammage, rotTop);
                CreateAtk(direction, new Vector3(transform.position.x + 0.5f * direction, transform.position.y + 0.6f, transform.position.z), sr, Lv3AtkDammage, 0f);
                CreateAtk(direction, new Vector3(transform.position.x + 0.4f * direction, transform.position.y + 0.5f, transform.position.z), sr, Lv3AtkDammage, rotBot);
                break;
            default:
                Debug.LogWarning("Player Atk Lv not found!");
                break;
        }
    }

    //void CreateAtk(int direction, Vector3 weaponPOS, SpriteRenderer sr, int atkDammage)
    //{
    //    GameObject temp = ObjectPooler.GetInstance().SpawnFromPool("Scythe", weaponPOS);
    //    temp.GetComponentInChildren<SpriteRenderer>().flipX = sr.flipX;
    //    temp.GetComponent<Scythe>().direction = direction;
    //    temp.GetComponent<Scythe>().dammage = atkDammage;



    //    StartCoroutine(SetInactiveAfterTime(0.75f, temp));
    //}

    void CreateAtk(int direction, Vector3 weaponPOS, SpriteRenderer sr, int atkDammage, float rotation)
    {
        GameObject temp = ObjectPooler.GetInstance().SpawnFromPool("Scythe", weaponPOS);
        temp.GetComponentInChildren<SpriteRenderer>().flipX = sr.flipX;
        temp.GetComponent<Scythe>().direction = direction;
        temp.GetComponent<Scythe>().dammage = atkDammage;
        temp.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotation);

        StartCoroutine(SetInactiveAfterTime(0.75f, temp));
    }

    IEnumerator SetInactiveAfterTime(float time, GameObject atk)
    {
        yield return new WaitForSeconds(time);
        atk.SetActive(false);
    }

    private void playersDeath()
    {
        playerIsAlive = false;
    }
}


