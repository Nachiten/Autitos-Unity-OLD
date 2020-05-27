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
        float moverVertical = Input.GetAxis("Vertical");

        // Limitar a velocidad maxima
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        // Calcular vector fuerza hacia adelante
        Vector3 vectorAdelante = moverVertical * this.transform.forward * speed;

        // Ejercer fuerza hacia adelante
        rb.AddForce(vectorAdelante);

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
    }

    // Rotar auto hacia los costados
    void girarHacia(float unValor) {
        this.transform.Rotate(0, rb.velocity.magnitude * unValor, 0);
    }


}
