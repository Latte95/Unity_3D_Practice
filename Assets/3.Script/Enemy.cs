using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float deltaTime;

    Rigidbody rigid;
    public GameObject player;

    public GameObject bullet;
    public float bulletSpeed = 0.7f;
    public float maxShotDelay;
    public float curShotDelay;

    void Awake()
    {
        deltaTime = Time.deltaTime;
    }

    void Update()
    {
        Fire();
        Reload();
    }

    void Fire()
    {
        if (curShotDelay < maxShotDelay)
        {
            return;
        }

        GameObject instantBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody rigidBullet = instantBullet.GetComponent<Rigidbody>();

        Vector3 dirVec = player.transform.position - transform.position;
        rigidBullet.AddForce(bulletSpeed * dirVec, ForceMode.Impulse);

        curShotDelay = 0;
    }

    void Reload()
    {
        curShotDelay += deltaTime;
    }

    void Attack()
    {
    }
}
