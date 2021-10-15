using UnityEngine;

public class DetectarColisionCheckpoint : MonoBehaviour
{
    private int numeroCheckpoint;

    private void Awake()
    {
        // Obtengo el nombre completo del checkpoint
        var nombrePadre = transform.parent.name;

        // Obtengo el numero de checkpoin
        numeroCheckpoint = int.Parse(nombrePadre.Split(' ')[1]);
    }
    
    void OnTriggerEnter(Collider collision)
    {
        ManejarJuego.tocarUnCheckpoint(numeroCheckpoint);
    }
}
