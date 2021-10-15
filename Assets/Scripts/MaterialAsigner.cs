using UnityEngine;

public class MaterialAsigner : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    
    void Awake()
    {
        // Buscar hijo con nombre checkpoint tube
        // Obtener mesh rendeder
        foreach (Transform child in transform)
            if (child.name == "Checkpoint Tube")
                meshRenderer = child.GetComponent<MeshRenderer>();
    }

    public void assignMaterial(Material newMaterial)
    {
        // Asignar material que corresponde
        meshRenderer.material = newMaterial;
    }

}
