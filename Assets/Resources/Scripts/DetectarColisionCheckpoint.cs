using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionCheckpoint : MonoBehaviour
{
    // Cuando toca por primera vez
    void OnTriggerEnter(Collider collision)
    {
        ManejarJuego.tocarUnCheckpoint(this.gameObject);
    }

    /*
    // Cuando deja de tocar
    void OnTriggerExit(Collider collision)
    {
        Debug.Log("Dejaste de tocar el checkpoint: " + this.gameObject.name);
    }

    // Cuando se queda tocando
    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Todavia estas tocando: " + this.gameObject.name);
    }*/

}
