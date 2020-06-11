using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejarJuego : MonoBehaviour
{

    // <3
    public bool noeEsTierna = true;
    static bool gano = false;

    static int vueltasTotales;
    static int checkpointsTotales;

    static int checkpointATocar = 1;
    static int vueltasActuales = 0;

    static Material checkpointProximo;
    static Material checkpointTocado;
    static Material checkpointNoToca;

    static bool terminoVuelta = false;

    private void Start()
    {
        vueltasTotales = leerVueltasTotalesDeConfig();

        Debug.Log("La cantidad de vueltas en este nivel es: " + vueltasTotales);

        inicializarTexturas();

        checkpointsTotales = cantidadCheckpoints();

        Debug.Log("La cantidad de checkpoints en este nivel es: " + checkpointsTotales);

        asignarTextuasIniciales();
        
    }

    public static int leerVueltasTotalesDeConfig() {
        DatosConfig config = Resources.Load<DatosConfig>("Scripts/ScriptableObjects/Config");

        int indexEscenaActual = SceneManager.GetActiveScene().buildIndex;

        return config.VueltasPorNivel[indexEscenaActual - 1];
    }

    public static int getVueltasTotales() {
        return vueltasTotales;
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

    public static int cantidadCheckpoints() {
        GameObject[] losCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        if (losCheckpoints.Length == 0)
        {
            Debug.LogError("No encontré ningun objeto checkpoint");
        }
        
        return losCheckpoints.Length;
    }

    static void asignarTextuasIniciales() {

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
        //Debug.Log("El numero de checkpoint tocado es: " + numeroDeCheckpoint);

        // Es el checkpoint que hay que tocar
        if (numeroDeCheckpoint == checkpointATocar)
        {

            // Modifico UI valor de checkpoint tocado
            ManejarUI.valorDeCheckpointA(numeroDeCheckpoint);

            //Debug.Log("Tocaste el checkpoint indicado");
            checkpointATocar++;

            // Ya toque todos los checkpoints
            if (checkpointATocar > checkpointsTotales)
            {
                //Debug.Log("Tocaste ya todos los checkpoint");
                // Puede tocar la meta desde aca :D
                terminoVuelta = true;
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
            //Debug.Log("El checkpoint que tocaste no sirve para nada");
        }
    }

    public static void verSiGano() {
        if (terminoVuelta)
        {
            if (gano) return;

            // Modificar UI de cantidadVueltas
            ManejarUI.valorDeVueltaA(vueltasActuales + 1);

            if (vueltasActuales + 1 == vueltasTotales)
            {
                Debug.Log("Ganaste capoeira :D");
                Timer.ganoNivel();
                Timer.terminoUnaVuelta();
                gano = true;
                return;
            }
            else {
                Debug.Log("Terminaste la vuelta");
            }


            // Reseteo valores iniciales para comenzar siguiente vuelta
            terminoVuelta = false;
            asignarTextuasIniciales();
            checkpointATocar = 1;
            ManejarUI.valorDeCheckpointA(0);

            // Asigno valor a reloj de ultima vuelta
            Timer.terminoUnaVuelta();

            vueltasActuales++;
        }
        else {
            Debug.Log("Todavia no tocaste todos los checkpoints");
        }
    }
}
