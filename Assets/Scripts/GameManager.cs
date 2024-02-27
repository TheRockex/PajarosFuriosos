using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public BirdSpawner birdSpawner;
    public int level;

    void Start()
    {
        Time.timeScale = 1f;
        ActivateSpawner();
    }

    void ActivateSpawner()
    {
        if (birdSpawner != null)
        {
            birdSpawner.SpawnNextBird();
        }
        else
        {
            Debug.LogError("No se ha asignado un BirdSpawner al GameManager.");
        }
    }

    public void PasarNivel()
    {
        SceneManager.LoadScene("Level " + (level + 1));
    }

    public void RepetirNivel()
    {
        SceneManager.LoadScene("Level " + level);
    }

    public void VolverMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
