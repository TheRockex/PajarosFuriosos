using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdSpawner : MonoBehaviour
{
    public GameObject[] birdPrefabs;
    public int totalBirds = 4;
    public Transform pivote;
    public float initialGravity = 0f;

    private int birdsSpawned = 0;

    void Start()
    {
    }

    public GameObject SpawnNextBird()
    {
        if (birdsSpawned >= totalBirds)
        {
            SceneManager.LoadScene("MenuInicial");
            return null;
        }

        Vector3 spawnPosition = pivote.position;

        GameObject nextBird = Instantiate(birdPrefabs[birdsSpawned], spawnPosition, Quaternion.identity);

        // Verificar el tipo de pájaro y asignar el pivote correspondiente
        if (nextBird.CompareTag("Pajaro"))
        {
            AssignPivoteToPajaro(nextBird);
        }
        else if (nextBird.CompareTag("PajaroAmarillo"))
        {
            AssignPivoteToPajaroAmarillo(nextBird);
        }
        else if (nextBird.CompareTag("PajaroBomba"))
        {
            AssignPivoteToPajaroBomba(nextBird);
        }
        else if (nextBird.CompareTag("PajaroHuevo"))
        {
            AssignPivoteToPajaroHuevo(nextBird);
        }

        birdsSpawned++;

        return nextBird;
    }

    private void AssignPivoteToPajaro(GameObject bird)
    {
        Pajaro pajaroScript = bird.GetComponent<Pajaro>();
        if (pajaroScript != null && pivote != null)
        {
            pajaroScript.pivote = pivote;

            Rigidbody2D rb = bird.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = initialGravity;
            }
        }
    }

    private void AssignPivoteToPajaroAmarillo(GameObject bird)
    {
        PajaroAmarillo pajaroAmarilloScript = bird.GetComponent<PajaroAmarillo>();
        if (pajaroAmarilloScript != null && pivote != null)
        {
            pajaroAmarilloScript.pivote = pivote;

            Rigidbody2D rb = bird.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = initialGravity;
            }
        }
    }

    private void AssignPivoteToPajaroBomba(GameObject bird)
    {
        PajaroBomba pajaroBombaScript = bird.GetComponent<PajaroBomba>();
        if (pajaroBombaScript != null && pivote != null)
        {
            pajaroBombaScript.pivote = pivote;

            Rigidbody2D rb = bird.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = initialGravity;
            }
        }
    }

    private void AssignPivoteToPajaroHuevo(GameObject bird)
    {
        PajaroHuevo pajaroHuevoScript = bird.GetComponent<PajaroHuevo>();
        if (pajaroHuevoScript != null && pivote != null)
        {
            pajaroHuevoScript.pivote = pivote;

            Rigidbody2D rb = bird.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = initialGravity;
            }
        }
    }
}




