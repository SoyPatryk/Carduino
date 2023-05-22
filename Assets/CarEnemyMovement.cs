using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemyMovement : MonoBehaviour
{
    public float speed = 20; // Velocidad de movimiento

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Aplicar una velocidad constante en el eje Z
        Vector3 movement = new Vector3(0f, 0f, speed);
        rb.velocity = movement;
    }
}
