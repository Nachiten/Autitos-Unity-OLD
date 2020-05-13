using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegarCamara : MonoBehaviour
{
    Transform transformCamara;
    public GameObject auto;
    Transform transformAuto;

    // Start is called before the first frame update
    void Start()
    {
        transformCamara = this.gameObject.GetComponent<Transform>();

        transformAuto = auto.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionCamara = new Vector3(transformAuto.position.x, transformAuto.position.y + 3.78f, transformAuto.position.z -3.88f);

        transformCamara.position = posicionCamara;
    }
}
