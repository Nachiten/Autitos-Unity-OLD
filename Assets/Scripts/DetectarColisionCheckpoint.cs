using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionCheckpoint : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        ManejarJuego.tocarUnCheckpoint(this.gameObject);
    }
    /*
    void OnTriggerExit(Collider collision)
    {
        Debug.Log("Dejaste de tocar el checkpoint: " + this.gameObject.name);
    }

    void OnTriggerStay(Collider collision)
    {
        Debug.Log("Todavia estas tocando: " + this.gameObject.name);
    }*/

}
