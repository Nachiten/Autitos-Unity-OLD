using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba1 : MonoBehaviour
{

    Transform[] transformsCubos;


    // Se llama cuando el codigo se ejecuta por primera vez (solo una vez)
    void Start()
    {

        Debug.Log("Juego Inciado");

        GameObject[] listaCubos;
        
        listaCubos = GameObject.FindGameObjectsWithTag("Bloque");

        transformsCubos = new Transform[6];

        int i = 0;
        foreach (GameObject unObjecto in listaCubos) {
            transformsCubos[i] = unObjecto.GetComponent<Transform>();
            i++;
        }

    }

    // Se llama una vez por fotograma FPS [Frames Per Second]
    void Update()
    {
        if (Input.GetKeyDown("w")) // Mover adelante
        {
            moverBloque(0, 5);
        }

        if (Input.GetKeyDown("s")) // Mover atras
        {
            moverBloque(0, -5);
        }

        if (Input.GetKeyDown("a")) // Mover izquierda
        {
            moverBloque(-5, 0);
        }

        if (Input.GetKeyDown("d")) // Mover derecha
            // GetKeyDown [Key = Tecla, Down = Apretar, Up = Soltar] || GetKeyUp es otra opcion
        {
            moverBloque(5, 0);
        }


    }

    void moverBloque(int offsetX, int offsetZ)
    {
        foreach (Transform unTransform in transformsCubos) {
            unTransform.position = new Vector3(unTransform.position.x + offsetX, unTransform.position.y, unTransform.position.z + offsetZ);
        }
    }

    //void FixedUpdate() { 
    
    //}
}
