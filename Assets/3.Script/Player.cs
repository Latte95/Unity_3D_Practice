using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;

    public int hp = 10;

    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    float stoppTime = 0.5f;
    float damageTime = 1f;

    float deltaTime;

    public bool isJump;
    public bool isStopped;
    public bool isDamaged;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        deltaTime = Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Floor"))
        {
            isJump = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                rigid.position = new Vector3(rigid.position.x, 0.5f, rigid.position.z);
                break;
            case "Enemy":
                if (!isDamaged)
                {
                    isDamaged = true;
                    StartCoroutine("Damaged");
                    //Invoke("Damage", damageTime);
                }
                break;
        }
        if (!collision.gameObject.tag.Equals("Enemy"))
        {
            isDamaged = false;
        }
    }

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(damageTime);
        if (isDamaged)
        {
            Damage();
            isDamaged = false;
        }
    }

    void Damage()
    {
        hp--;
    }

    void OnTriggerStay(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "Propeller":
                if (!isStopped)
                {
                    isStopped = true;
                    StartCoroutine("OffStop2");
                }
                break;
        }
    }

    IEnumerator OffStop2()
    {
        yield return new WaitForSeconds(stoppTime);
        isStopped = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(h, rigid.velocity.y, v);
        if (!isStopped)
        {
            transform.Translate(deltaTime * speed * vec);
        }
    }

}
