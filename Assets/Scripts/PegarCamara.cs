using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCamara : MonoBehaviour
{
    Transform transformCamara;
    Transform transformBola;

    // Start is called before the first frame update
    void Start()
    {
        transformCamara = this.gameObject.GetComponent<Transform>();

        transformBola = GameObject.Find("Bola").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionCamara = new Vector3(transformBola.position.x, transformBola.position.y + 3.78f, transformBola.position.z -3.88f);

        transformCamara.position = posicionCamara;
    }
}
