using UnityEngine;
using UnityEngine.UI;

public class manejarPreguntas : MonoBehaviour
{
    Pregunta preguntaActual;

    // Start is called before the first frame update
    void Start()
    {
        preguntaActual = manejarArchivo.generarPregunta(1);
        preguntaActual.ponerPregunta();
    }

    public void opcion(int opcion) 
    {
        int preguntaAGenerar = preguntaActual.rtaPreguntas[opcion - 1];

        preguntaActual = manejarArchivo.generarPregunta(preguntaAGenerar);
        preguntaActual.ponerPregunta();
    }
}

public class Pregunta {
    string pregunta;
    string rta1;
    string rta2;
    public int[] rtaPreguntas = new int[2];

    Text textoPregunta;
    Text textoRta1;
    Text textoRta2;

    public Pregunta(string unaPregunta, string unaRta1, string unaRta2, int unaRta1Pregunta, int unaRta2Pregunta)
    {
        pregunta = unaPregunta;
        rta1 = unaRta1;
        rta2 = unaRta2;
        rtaPreguntas[0] = unaRta1Pregunta;
        rtaPreguntas[1] = unaRta2Pregunta;

        GameObject textoMensaje = GameObject.Find("Mensaje");
        GameObject unRta1 = GameObject.Find("Rta1");
        GameObject unRta2 = GameObject.Find("Rta2");

        if (textoMensaje == null) {
            Debug.LogError("textoMensjae es null D:");
            return;
        }
        if (unRta1 == null) {
            Debug.LogError("unTextoRta1 es null D:");
            return;
        }
        if (unRta2 == null) {
            Debug.LogError("unTextoRta2 es null D:");
            return;
        }


        int numero = 1;
        
        switch (numero)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
        }
         

        textoPregunta = textoMensaje.GetComponent<Text>();
        textoRta1 = unRta1.GetComponent<Text>();
        textoRta2 = unRta2.GetComponent<Text>();
    }

    public void ponerPregunta() {
        textoPregunta.text = pregunta;
        textoRta1.text = rta1;
        textoRta2.text = rta2;

        Debug.Log("Se puso la pregunta: " + pregunta);
    }

}
