using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text timerGlobalText;
    static Text timerUltVueltaText;

    float tiempoGlobal;
    static float tiempoUltimaVuelta;
    static bool gano = false;

    /* -------------------------------------------------------------------------------- */

    void Start()
    {
        timerGlobalText = GameObject.Find("ValorTiempoGlobal").GetComponent<Text>();
        if (timerGlobalText == null) {
            Debug.LogError("No pude encontrar el reloj global");
        }

        timerUltVueltaText = GameObject.Find("ValorTiempoVuelta").GetComponent<Text>();
        if (timerUltVueltaText == null)
        {
            Debug.LogError("No pude encontrar el reloj ultima vuelta");
        }
    }

    /* -------------------------------------------------------------------------------- */

    public static void ganoNivel() {
        gano = true;
    }

    void Update()
    {
        if (!gano)
        {
            tiempoGlobal += Time.deltaTime;
            tiempoUltimaVuelta += Time.deltaTime;

            convertirYEscribirTiempo(tiempoGlobal, timerGlobalText);

            /*
            string minutes = Mathf.Floor((tiempoGlobal % 3600) / 60).ToString("00");
            string seconds = Mathf.Floor(tiempoGlobal % 60).ToString("00");
            string miliseconds = Mathf.Floor(tiempoGlobal % 6 * 10 % 10).ToString("0");
            */

            //timerGlobalText.text = minutes + ":" + seconds + ":" + miliseconds;
        }

    }

    static void convertirYEscribirTiempo(float unTiempo, Text unTextoUI) {
        string minutos = Mathf.Floor((unTiempo % 3600) / 60).ToString("00");
        string segundos = Mathf.Floor(unTiempo % 60).ToString("00");
        string milisegundos = Mathf.Floor(unTiempo % 6 * 10 % 10).ToString("0");

        unTextoUI.text = minutos + ":" + segundos + ":" + milisegundos;
    }

    public static void terminoUnaVuelta() {

        Debug.Log("Termino una vuelta");

        convertirYEscribirTiempo(tiempoUltimaVuelta, timerUltVueltaText);

        /*
        string minutes = Mathf.Floor((tiempoUltimaVuelta % 3600) / 60).ToString("00");
        string seconds = Mathf.Floor(tiempoUltimaVuelta % 60).ToString("00");
        string miliseconds = Mathf.Floor(tiempoUltimaVuelta % 6 * 10 % 10).ToString("0");
        */

        // timerUltVueltaText.text = minutes + ":" + seconds + ":" + miliseconds;

        tiempoUltimaVuelta = 0;
    }
}
