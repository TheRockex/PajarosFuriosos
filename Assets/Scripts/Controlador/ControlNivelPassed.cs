using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlNivelPassed : MonoBehaviour
{
    public GameObject canvasObj;

    public void VerificarCerdos()
    {
        GameObject[] cerdos = GameObject.FindGameObjectsWithTag("cerdo");
        GameObject[] cerdosMago = GameObject.FindGameObjectsWithTag("mago");

        int totalCerdos = cerdos.Length + cerdosMago.Length;

        if (totalCerdos == 0)
        {
            Time.timeScale = 0f;
            ControlNivel.instance.AumentarNiveles();
            canvasObj.SetActive(true);
        }
    }

    void Update()
    {
        VerificarCerdos();
    }
}
