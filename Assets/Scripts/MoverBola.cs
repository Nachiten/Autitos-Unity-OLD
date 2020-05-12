using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBola : MonoBehaviour
{
    public bool muestroOculto = true;

    // :3 :$
    public bool noeEsTierna = true;

    GameObject elCilindro;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Codigo MoverCubo inicializado..");
        elCilindro = GameObject.Find("Ocultar");

        if (elCilindro == null)
        {
            Debug.LogError("Capo no encuentro el cilindro");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")) // Mover adelante
        {
            ejercerFuerza(0, 1);
        }

        if (Input.GetKey("s")) // Mover atras
        {
            ejercerFuerza(0, -1);
        }

        if (Input.GetKey("a")) // Mover izquierda
        {
            ejercerFuerza(-1, 0);
        }

        if (Input.GetKey("d")) // Mover derecha
        // GetKeyDown [Key = Tecla, Down = Apretar, Up = Soltar] || GetKeyUp es otra opcion
        {
            ejercerFuerza(1, 0);
        }

        if (muestroOculto)
        {
            elCilindro.SetActive(true);
        }
    }

    void ejercerFuerza(int offsetX, int offsetZ)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(2000 * Time.deltaTime * offsetX, 0, 2000 * Time.deltaTime * offsetZ);
    }

    void OnCollisionEnter(Collision collision)
    {
        /*if (!(collision.gameObject.name == "Plano")) {
            Debug.Log("Toque un pino :D");
            this.enabled = false;
        }*/
        // .gameObject | el gameObject con el que colisione
        // .name string nombre
        if (collision.gameObject.name == "Destruir")
        {
            Debug.Log("No me quiero ir señor stark");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "Ocultar")
        {
            Debug.Log("Ocultandome... adiooos");
            collision.gameObject.SetActive(false);
            muestroOculto = false;
        }
        if (collision.gameObject.name == "Invisible")
        {
            // collision.gameObject.GetComponent<MeshRenderer>().enabled(false);
            Debug.Log("Tocaste el objeto invisible muahahaha");
        }
    }


}
