using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotation : MonoBehaviour
{
    public float rotationSpeed = 1000;
    float deltaTime;

    void Awake()
    {
        deltaTime = Time.deltaTime;
    }

    void Update()
    {
        transform.Rotate(deltaTime * rotationSpeed * Vector3.up);
    }
}
