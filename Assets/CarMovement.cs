using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class CarMovement : MonoBehaviour
{
    // Public properties
    public float timeAccel;
    public float force;

    // Private properties
    private float xAxis;
    private Rigidbody _rb;
    public static float horAxis;
    private SerialPort serialPort;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        InvokeRepeating("Acceleration", timeAccel, timeAccel);

        // Inicializar el puerto serial
        serialPort = new SerialPort("COM9", 9600);

        // Abrir el puerto
        serialPort.Open();

        // Establecer tiempo máximo de espera para lectura
        serialPort.ReadTimeout = 100; // Milisegundos
    }

    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");

        try
        {
            // Leer datos del puerto serial si está abierto
            if (serialPort.IsOpen)
            {
                string data = serialPort.ReadLine().Trim();
                Debug.Log(data);

                switch (data)
                {
                    case "L":
                        horAxis = Mathf.Lerp(horAxis, -10f, 10f * Time.deltaTime);
                        break;
                    case "R":
                        horAxis = Mathf.Lerp(horAxis, 10f, 10f * Time.deltaTime);
                        break;
                    case "LR":
                        horAxis = Mathf.Lerp(horAxis, 0f, 10f * Time.deltaTime);
                        break;
                    default:
                        horAxis = Mathf.Lerp(horAxis, 0f, 10f * Time.deltaTime);
                        break;
                }
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    private void FixedUpdate()
    {
        Vector3 forceVector = new Vector3(horAxis * force, 0f, 0f);
        _rb.AddForce(forceVector);
    }

    private void Acceleration()
    {
        force = force + 0.1f;
    }
}
