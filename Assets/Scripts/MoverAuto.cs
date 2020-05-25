using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class MoverAuto : MonoBehaviour
{

    // :3 :$ <3
    public bool noeEsTierna = true;

    //Variables
    GameObject referencia;
    GameObject textoVelocidad;
    Rigidbody rb;
    Text texto;

    float speed = 17;
    float maxSpeed = 27;

    /* -------------------------------------------------------------------------------- */

    // Llamado al inicio
    void Start()
    {
        /* OBSOLETO (depracated)
        referencia = GameObject.Find("Referencia");

        // Checkeo de errores
        if (referencia == null) {
            Debug.LogError("No pude encontrar al objeto llamado 'Referencia'");
        }*/

        rb = this.GetComponent<Rigidbody>();

        // Checkeo de errores
        if (rb == null) {
            Debug.LogError("No encontre el RB del auto");
        }

        //Debug.Log("referencia.transform.forward: " + referencia.transform.forward);
        //Debug.Log("referencia.transform.right: " + referencia.transform.right);
    }

    /* -------------------------------------------------------------------------------- */

    // Se llama cada fotograma
    void FixedUpdate()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        UnityEngine.Vector3 vectorAdelante = moverVertical * this.transform.forward * speed;

        // TODO: Voltear de manera normal no directo a la derecha (sumando el vector adelante)
        UnityEngine.Vector3 vectorLateral = moverHorizontal * this.transform.right * speed;

        // Debug.Log("vectorAdelante: " + vectorAdelante);
        // Debug.Log("vectorLateral: " + vectorLateral);

        rb.AddForce(vectorAdelante);
        rb.AddForce(vectorLateral);
    }


}
