using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ShootAtPlayer : MonoBehaviour
{

    mouvementSCript PlayerRef;
    [SerializeField] float shootCooldown, currentTime;
    [SerializeField] GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = mouvementSCript.instance;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= shootCooldown)
        {
            currentTime = 0f;
            Vector3 playerPos = mouvementSCript.instance.transform.position - transform.position;
            CreateAtk(playerPos, this.gameObject.transform.position, 1);
        }
    }

    void CreateAtk(Vector3 _targetDirection, Vector3 weaponPOS, int atkDammage)
    {
        GameObject temp = ObjectPooler.GetInstance().SpawnFromPool("DemonAtk", weaponPOS);

        Vector3 targetDirection = mouvementSCript.instance.transform.position - transform.position;
        targetDirection.y += 0.6f;

        // Normalize the target direction
        targetDirection.Normalize();

        float angleRadians = Mathf.Atan2(targetDirection.y, targetDirection.x);
        // Convert radians to degrees
        float angleDegrees = angleRadians * Mathf.Rad2Deg;

        if (angleDegrees < 0)
        {
            angleDegrees += 360;
        }

        temp.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

        temp.GetComponent<Scythe>().dammage = atkDammage;
        temp.GetComponent<Scythe>().direction = 1;

        StartCoroutine(SetInactiveAfterTime(1.25f, temp));
    }

    IEnumerator SetInactiveAfterTime(float time, GameObject atk)
    {
        yield return new WaitForSeconds(time);
        atk.SetActive(false);
    }
}
