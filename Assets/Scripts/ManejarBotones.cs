using UnityEngine;
using UnityEngine.SceneManagement;

public class ManejarBotones : MonoBehaviour
{
    public bool nachoTaCansado = true;

    private void Start()
    {
        // Saber la escena actual
        Debug.Log(SceneManager.GetActiveScene());
    }

    public void iniciarJuego() {
        SceneManager.LoadScene(1);

        // Moverme a una escena por un index

        // Moverme a la escena siguiente.
    }

    public void salir() { 
        Application.Quit(); 
    }


}
