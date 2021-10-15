using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejarJuego : MonoBehaviour
{
    static bool gano = false;

    static int vueltasTotales;
    static int checkpointsTotales;

    static int checkpointATocar = 1;
    static int vueltasActuales = 0;

    static Material checkpointProximo;
    static Material checkpointTocado;
    static Material checkpointNoToca;

    static bool terminoVuelta = false;

    private void Start()
    {
        vueltasTotales = leerVueltasTotalesDeConfig();

        inicializarTexturas();

        checkpointsTotales = cantidadCheckpoints();
        
        asignarTextuasIniciales();
        
        Debug.Log("La cantidad de vueltas en este nivel es: " + vueltasTotales + "\nLa cantidad de checkpoints en este nivel es: " + checkpointsTotales);
    }

    public static int leerVueltasTotalesDeConfig() {
        DatosConfig config = Resources.Load<DatosConfig>("ScriptableObjects/ConfigsNivel");

        int indexEscenaActual = SceneManager.GetActiveScene().buildIndex;

        return 5;
    }

    public static int getVueltasTotales() {
        return vueltasTotales;
    }

    void inicializarTexturas() {
        // Se asignan los 3 materiales de colores distintos
        checkpointProximo = Resources.Load<Material>("Materials/CheckpointProximo");
        checkpointTocado = Resources.Load<Material>("Materials/CheckpointTocado");
        checkpointNoToca = Resources.Load<Material>("Materials/CheckpointNoToca");

        // Chequeo de errores
        if (checkpointProximo == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointProximo");
        }

        if (checkpointTocado == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointTocado");
        }

        if (checkpointNoToca == null)
        {
            Debug.LogError("No pude encontrar la textura de checkpointNoToca");
        }
    }

    public static int cantidadCheckpoints() {
        GameObject[] losCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        if (losCheckpoints.Length == 0)
        {
            Debug.LogError("No encontré ningun objeto checkpoint");
        }
        
        return losCheckpoints.Length;
    }

    static void asignarTextuasIniciales() {

        for (int i = 1; i <= checkpointsTotales; i++)
        {
            Material materialAsignado = i == 1 ? checkpointProximo : checkpointNoToca;
            
            GameObject.Find("Checkpoint " + i).GetComponent<MaterialAsigner>().assignMaterial(materialAsignado);
        }
    }

    public static void tocarUnCheckpoint(int numeroDeCheckpoint) {
        Debug.Log("El numero de checkpoint tocado es: " + numeroDeCheckpoint);

        // Si no es el checkpoint que toca no hago nada
        if (numeroDeCheckpoint != checkpointATocar) 
            return;
        
        // Modifico UI valor de checkpoint tocado
        ManejarUI.valorDeCheckpointA(numeroDeCheckpoint);
            
        checkpointATocar++;

        // Ya toque todos los checkpoints
        if (checkpointATocar > checkpointsTotales)
        {
            // Puede tocar la meta desde aca :D
            terminoVuelta = true;
        }
        else
        {
            // Se setea el checkpoint siguiente a el color amarillo
            GameObject.Find("Checkpoint " + (numeroDeCheckpoint + 1)).GetComponent<MaterialAsigner>().assignMaterial(checkpointProximo);
        }

        // Seteo el checkpoint ya tocado
        GameObject.Find("Checkpoint " + numeroDeCheckpoint).GetComponent<MaterialAsigner>().assignMaterial(checkpointTocado);
    }

    public static void verSiGano() {
        if (terminoVuelta)
        {
            if (gano) 
                return;

            // Modificar UI de cantidadVueltas
            ManejarUI.valorDeVueltaA(vueltasActuales + 1);

            if (vueltasActuales + 1 == vueltasTotales)
            {
                Debug.Log("Ganaste capoeira :D");
                Timer.ganoNivel();
                Timer.terminoUnaVuelta();
                gano = true;
                return;
            }
            
            
            Debug.Log("Terminaste la vuelta");
            
            // Reseteo valores iniciales para comenzar siguiente vuelta
            terminoVuelta = false;
            asignarTextuasIniciales();
            checkpointATocar = 1;
            ManejarUI.valorDeCheckpointA(0);

            // Asigno valor a reloj de ultima vuelta
            Timer.terminoUnaVuelta();

            vueltasActuales++;
        }
        else {
            Debug.Log("Todavia no tocaste todos los checkpoints");
        }
    }
}
