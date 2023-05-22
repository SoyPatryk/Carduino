using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class CarMovement : MonoBehaviour
{
    //public properties

    public float timeAccel;


    //Private properties
    private float xAxis; 
    private  Rigidbody _rb;
    public int force;

    public static float horAxis;
    private SerialPort serialPort = new SerialPort("COM9", 9600);


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        InvokeRepeating("Acceleration", timeAccel, timeAccel);

        // Obrim el port
        serialPort.Open();

        // Temps màxim per intentar la connexió
        serialPort.ReadTimeout = 100; // Milisegons


    }

    public void Update()
    {
        xAxis = Input.GetAxis("Horizontal");

        // Fem servir el bloc try/catch per a evitar excepcions,
        // per exemple, quan no li arriba cap informació
        try
        {
            // Si arriba informació...
            if (serialPort.IsOpen)
            {
                // Llegim una línia i la guardem a una variable string
                // traient amb Trim els espais en blanc per davant i pel darrera
                string dades = serialPort.ReadLine().Trim();
                Debug.Log(dades);
                switch (dades)
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

    //public void FixedUpdate()
    //{
    //    Vector3 forceVector = new Vector3(xAxis * force, 0f, 0f);
    //    _rb.AddForce(forceVector);

    //}
    
    public void Acceleration() 
    {

        force++;

            
    }
}
