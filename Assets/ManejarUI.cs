using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManejarUI : MonoBehaviour
{
    static int vueltasTotales;
    static int checkpointsTotales;
    static Text textoCheckpoint;
    static Text textoVuelta;

    private void Start() {

        vueltasTotales = ManejarJuego.leerVueltasTotalesDeConfig();

        checkpointsTotales = ManejarJuego.cantidadCheckpoints();

        inicializarTextos();

        darValoresInicialesTextos();
    }

    void inicializarTextos() {
        
        textoCheckpoint = GameObject.Find("ValorCheckpoint").GetComponent<Text>();
        textoVuelta = GameObject.Find("ValorVuelta").GetComponent<Text>();

        if (textoCheckpoint == null)
        {
            Debug.LogError("No pude encontrar el objeto TextoCheckpoint");
        }

        if (textoVuelta == null)
        {
            Debug.LogError("No pude encontrar el objeto TextoVuelta");
        }
    }

    void darValoresInicialesTextos() {
        valorDeCheckpointA(0);
        valorDeVueltaA(0);
    }

    public static void valorDeVueltaA(int unValor) {
        textoVuelta.text = unValor + " / " + vueltasTotales;
    }

    public static void valorDeCheckpointA(int unValor)
    {
        textoCheckpoint.text = unValor + " / " + checkpointsTotales;
    }
}
