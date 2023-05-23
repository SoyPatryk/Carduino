using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Comprobar si colisiona con un objeto que tiene un BoxCollider y no tiene el tag "Wall"
        if (collision.collider is BoxCollider && !collision.gameObject.CompareTag("Wall"))
        {
            // Reiniciar la escena
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
