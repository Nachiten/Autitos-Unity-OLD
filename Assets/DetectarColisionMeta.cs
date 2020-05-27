using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColisionMeta : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        ManejarJuego.verSiGano();
    }
}
