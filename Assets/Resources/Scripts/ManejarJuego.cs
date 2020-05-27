using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarJuego : MonoBehaviour
{
    //bool[] arraysTocados;

    static int checkpointATocar = 1;
    static int checkpointsTotales;

    static Material checkpointProximo;
    static Material checkpointTocado;
    static Material checkpointNoToca;

    private void Start()
    {
        inicializarTexturas();

        calcularCantidadCheckpoints();

        asignarTextuasIniciales();
        
    }

    void inicializarTexturas() {
        // Se asignan los 3 materiales de colores distintos
        checkpointProximo = Resources.Load<Material>("Materials/CheckpointProximo");
        checkpointTocado = Resources.Load<Material>("Materials/CheckpointTocado");
        checkpointNoToca = Resources.Load<Material>("Materials/CheckpointNoToca");

        // Chequeo de errores
        if (checkpointProximo == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointProximo");
        }

        if (checkpointTocado == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointTocado");
        }

        if (checkpointNoToca == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointNoToca");
        }
    }

    void calcularCantidadCheckpoints() {
        GameObject[] losCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        if (losCheckpoints.Length == 0)
        {
            Debug.LogError("No encontré ningun objeto checkpoint");
        }

        checkpointsTotales = losCheckpoints.Length;
        Debug.Log("La cantidad de checkpoints en este nivel es: " + checkpointsTotales);
    }

    void asignarTextuasIniciales() {

        for (int i = 1; i <= checkpointsTotales; i++) {
            if (i == 1)
                GameObject.Find("Tubo Checkpoint " + i).GetComponent<MeshRenderer>().material = checkpointProximo;
            else
                GameObject.Find("Tubo Checkpoint " + i).GetComponent<MeshRenderer>().material = checkpointNoToca;
        }
    }

    public static void tocarUnCheckpoint(GameObject elCheckpoint) {

        // Obtener el numero del checkpoint tocado
        int numeroDeCheckpoint = short.Parse(elCheckpoint.name.Substring(elCheckpoint.name.Length - 1));
        Debug.Log("El numero de checkpoint tocado es: " + numeroDeCheckpoint);

        // Es el checkpoint que hay que tocar
        if (numeroDeCheckpoint == checkpointATocar)
        {
            Debug.Log("Tocaste el checkpoint indicado");
            checkpointATocar++;

            // Ya toque todos los checkpoints
            if (checkpointATocar > checkpointsTotales)
            {
                Debug.Log("Tocaste ya todos los checkpoint");
                // Puede tocar la meta desde aca :D
            }
            else
            {
                // Se setea el checkpoint siguiente a el color amarillo
                GameObject.Find("Tubo Checkpoint " + (numeroDeCheckpoint + 1)).GetComponent<MeshRenderer>().material = checkpointProximo;
            }

            // Se setea el checkpoint actual a ser verde
            GameObject.Find("Tubo Checkpoint " + numeroDeCheckpoint).GetComponent<MeshRenderer>().material = checkpointTocado;

        }
        else {
            Debug.Log("El checkpoint que tocaste no sirve para nada");
        }
    }
}
