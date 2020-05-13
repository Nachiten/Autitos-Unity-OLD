using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;

public class manejarArchivo : MonoBehaviour
{
    //[MenuItem("Tools/Write file")]

    void Start()
    {

    }

    void Update()
    {
        
    }

    public static Pregunta generarPregunta(int numPregunta) {

        string linea = leerLinea(numPregunta);

        string rta1Raw = recuperarLineaEntreComillas(linea, 1);
        string rta2Raw = recuperarLineaEntreComillas(linea, 2);

        int rta1Path = 0;
        int rta2Path = 0;

        string rta1 = separarPath(ref rta1Path, rta1Raw);
        string rta2 = separarPath(ref rta2Path, rta2Raw);

        // Pregunta, rta1, rta2, numeroPreguntaRta1, numeroPreguntaRta1
        return new Pregunta(recuperarLineaEntreComillas(linea, 0), rta1, rta2, rta1Path, rta2Path);

    }

    static string separarPath(ref int path, string rtaRaw) {

        string rtaSinPath = "";
        bool leerNum = false;

        foreach (char unCaracter in rtaRaw) {

            if (unCaracter == '_') {
                leerNum = true;
                continue;
            }

            if (leerNum) {  
                path = unCaracter - '0';
                return rtaSinPath;
            }

            else rtaSinPath += unCaracter;
            
        }

        return rtaSinPath;
    }

    private static string leerLinea(int linea)
    {
        string path = "Assets/ArchivosTexto/preguntas.txt";

        try
        {
            var lineas = new List<String>();

            int cantLineas = 0;

            // StreamReader se usa para leer archivos
            // La palabra "using" se asegura de cerrar el archivo
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

               
                while ((line = sr.ReadLine()) != null)
                {
                    lineas.Add(line);

                    if (cantLineas == linea - 1)
                    {
                        return line;
                    }

                    cantLineas++;
                }
                
            }

            if (cantLineas == 0) {
                Debug.LogError("El archivo está vacio!! Path: " + path);
                return "";
            }

            Debug.LogError("La pregunta numero:  " + linea + " en el path: " + path + " no pudo ser leida");
            return "";

            /*
            foreach (String unaLinea in lineas)
            {
                //Debug.Log(recuperarNumero(unaLinea));
                //Debug.Log(recuperarLineaEntreComillas(unaLinea, 0));
                //Debug.Log(recuperarLineaEntreComillas(unaLinea, 1));
                //Debug.Log(recuperarLineaEntreComillas(unaLinea, 2));

                Debug.Log(recuperarLineaEntreComillas(unaLinea, 3));
            }*/

        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.LogError("El archivo no pudo ser leido en la direccion: " + path);
            Debug.Log(e.Message);
            return "";
        }
    }

    char recuperarNumero(String unaLinea) {
        return unaLinea[0];
    }

    static string recuperarLineaEntreComillas(String unaLinea, int indiceLinea) {

        int comillasAIgnorar = 0;

        bool leer = false;

        int guardarRespuesta = indiceLinea;

        String respuesta = "";

        while (indiceLinea > 0) {
            comillasAIgnorar += 2;
            indiceLinea--;
        }

        foreach (char unCaracter in unaLinea)
        {
            if (unCaracter == '"')
            {
                if (comillasAIgnorar > 0) {
                    comillasAIgnorar--;
                    continue;
                }

                leer = !leer;
                if (!leer) return respuesta;

                continue;
            }

            if (leer)
            {
                respuesta += unCaracter;
            }
        }

        Debug.LogError("No se pudo leer la linea entre comillas. Numero: " + guardarRespuesta + ". Linea: " + unaLinea);
        return "No se pudo leer la linea entre comillas. Numero: " + guardarRespuesta + ". Linea: " + unaLinea;

    }

    /*
    void escribirLineas()
    {
        try
        {
            //Write some text to the test.txt file
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                for (int i = 32; i < 53; i++)
                {
                    writer.WriteLine("Linea " + i);
                }
            }
        }
        catch (Exception e)
        {
            // Let the user know what went wrong.
            Debug.Log("El archivo no pudo ser leido en la direccion: " + path);
            Debug.Log(e.Message);
        }
    }*/

}