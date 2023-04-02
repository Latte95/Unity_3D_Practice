using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rigid;
    float deltaTime;
    public float speed = 5.0f;
    public float jumpForce = 12.0f;
    public bool isJump;

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

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            //Vector3 vec = new Vector3(rigid.velocity.x, 1, rigid.velocity.z);
            //transform.Translate(deltaTime * jumpForce * vec);
            rigid.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(h, rigid.velocity.y, v);
        transform.Translate(deltaTime * speed * vec);
    }


}
