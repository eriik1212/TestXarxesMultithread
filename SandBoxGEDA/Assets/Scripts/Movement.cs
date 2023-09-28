using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Movement : MonoBehaviour
{
    public float forceAmount = 5.0f;
    public float rotationSpeed = 50.0f; // Nueva variable para controlar la velocidad de rotación
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 force = new Vector3(moveHorizontal, 0.0f, moveVertical) * forceAmount;
        rb.AddForce(force);

        // Rotar el objeto automáticamente alrededor de su eje Y local
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

}


