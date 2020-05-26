using JetBrains.Annotations;
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

    // Llamado al inicio una unica vez
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        // Checkeo de errores
        if (rb == null) {
            Debug.LogError("No encontre el RB del auto");
        }
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

        Vector3 vectorAdelante = moverVertical * this.transform.forward * speed;

        // TODO: Voltear de manera normal no directo a la derecha (sumando el vector adelante)
        //Vector3 vectorLateral = moverHorizontal * (this.transform.right + new Vector3(0,0,1) )  * speed;

        // Voltear a la derecha
        if (Input.GetKey("d")) 
        {
            // Se gira proporcional a la velocidad de movimiento
            girarHacia( 0.5f / 3 );
        }

        // Voltear a la izquierda
        if (Input.GetKey("a"))
        {
            // Se gira proporcional a la velocidad de movimiento
            girarHacia( -0.5f / 3 );
        }

        //Debug.Log(this.transform.eulerAngles);

        //Debug.Log("La velocidad es: " + rb.velocity.magnitude);

        rb.AddForce(vectorAdelante);
        //rb.AddForce(vectorLateral);
    }

    void girarHacia(float unValor) {
        this.transform.Rotate(0, rb.velocity.magnitude * unValor, 0);
    }


}
