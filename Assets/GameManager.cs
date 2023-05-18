using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] cars;
    public Transform[] spawnPoints;
    public float timeToSpawn;
    public int timeToDestroy;
    public float forceMagnitude;

    void Start()
    {
        InvokeRepeating("SpawnVehicle", timeToSpawn, timeToSpawn);
    }

    private void SpawnVehicle()
    {
        int randomCarIndex = Random.Range(0, cars.Length);
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject newCar = Instantiate(cars[randomCarIndex], spawnPoints[randomSpawnIndex].position, spawnPoints[randomSpawnIndex].rotation);

        Rigidbody carRigidbody = newCar.GetComponent<Rigidbody>();
        carRigidbody.AddForce(newCar.transform.forward * forceMagnitude, ForceMode.VelocityChange);
        Destroy(newCar, timeToDestroy);
    }
}



