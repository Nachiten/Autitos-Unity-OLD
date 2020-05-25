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
    static GameObject[] checkPointsVisibles;

    private void Start()
    {
        checkpointProximo = Resources.Load<Material>("Materials/CheckpointProximo");
        checkpointTocado = Resources.Load<Material>("Materials/CheckpointTocado");
        checkpointNoToca = Resources.Load<Material>("Materials/CheckpointNoToca");

        if (checkpointProximo == null) {
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

        GameObject[] losCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkPointsVisibles = GameObject.FindGameObjectsWithTag("CheckpointVisible");

        if (losCheckpoints.Length != checkPointsVisibles.Length) {
            Debug.LogError("Hay una incosistencia entre los checkpoints y checkpoints visibles");
        }

        checkearErroresDe(losCheckpoints);
        checkearErroresDe(checkPointsVisibles);

        checkpointsTotales = losCheckpoints.Length;
    }

    void checkearErroresDe(GameObject[] unosObjetos) {
        if (unosObjetos.Length == 0)
        {
            Debug.LogError("No hay ningun objeto checkpoint");
        }
        else
        {
            Debug.Log("La cantidad de checkpoints es: " + unosObjetos.Length);
        }
    }

    public static void tocarUnCheckpoint(GameObject elCheckpoint) {
        int numeroDeCheckpoint = short.Parse(elCheckpoint.name.Substring(elCheckpoint.name.Length - 1));
        Debug.Log("El numero de checkpoint tocado es: " + numeroDeCheckpoint);

        if (numeroDeCheckpoint == checkpointATocar) {
            Debug.Log("Tocaste el checkpoint indicado");
            checkpointATocar++;
        }

        if (checkpointATocar > checkpointsTotales)
        {
            Debug.Log("Tocaste ya todos los checkpoint");
        }
        else 
        {
            GameObject.Find("Cubo Checkpoint " + (numeroDeCheckpoint + 1)).GetComponent<MeshRenderer>().material = checkpointProximo;
        }

        GameObject.Find("Cubo Checkpoint " + numeroDeCheckpoint).GetComponent<MeshRenderer>().material = checkpointTocado;


    }
}
