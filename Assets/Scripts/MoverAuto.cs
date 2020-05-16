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
        referencia = GameObject.Find("Referencia");

        rb = this.GetComponent<Rigidbody>();

        if (rb == null) {
            Debug.Log("No encontre el RB");
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

        UnityEngine.Vector3 vectorVetical = moverVertical * referencia.transform.forward * speed;
        UnityEngine.Vector3 vectorHorizontal = moverHorizontal * referencia.transform.right * speed;

        //Debug.Log("Vector vertical: " + vectorVetical);
        //Debug.Log("Vector horizontal: " + vectorHorizontal);

        rb.AddForce(vectorVetical);
        rb.AddForce(vectorHorizontal);
    }


}
