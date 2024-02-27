using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReyCerdo : MonoBehaviour
{
    // Aseg�rate de asignar la referencia al controlador del viento en el Inspector de Unity
    public WindController windController;

    void OnDestroy()
    {
        if (windController != null)
        {
            // Llama al m�todo para desactivar el viento cuando el rey cerdo muere
            windController.MagiaOFF();
        }
    }
}
