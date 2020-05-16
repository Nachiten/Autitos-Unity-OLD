using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCamara : MonoBehaviour
{
    // Variables
    float sensibilidad = 2;

    GameObject jugador;
    GameObject referencia;
    Vector3 distancia;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Asignar los Game Objects
        referencia = GameObject.Find("Referencia");
        jugador = GameObject.Find("Car_1");

        //Asignar Distancia
        distancia = this.transform.position - jugador.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Calcula la distancia del jugador
        distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * distancia;

        // La camara cambia su posicion respecto a la posicion del jugador
        transform.position = jugador.transform.position + distancia + offset;

        // La camara mira hacia el jugador
        transform.LookAt(jugador.transform.position);

        // Referencia para que los controles no cambien
        Vector3 copiarRotacion = new Vector3(0, transform.eulerAngles.y, 0);

        // Rotar la referencia
        referencia.transform.eulerAngles = copiarRotacion;
    }


}
