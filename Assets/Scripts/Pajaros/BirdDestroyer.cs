using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDestroyer : MonoBehaviour
{
    private BirdSpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<BirdSpawner>();
    }

    private void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.SpawnNextBird(); 
        }
    }
}
