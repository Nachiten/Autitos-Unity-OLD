using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAuto : MonoBehaviour
{

    // :3 :$ <3
    public bool noeEsTierna = true;


    // Start is called before the first frame update
    void Start()
    {
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
    }


}
