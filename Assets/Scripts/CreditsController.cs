using UnityEngine;

public class CreditsController : MonoBehaviour
{
    public Material tvOnMaterial;
    private Material defaultMaterial;
    private Renderer objRenderer; // To hold the Renderer component

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>(); // Get the Renderer component
        defaultMaterial = objRenderer.material; // Store the original material
    }

    private void OnEnable()
    {
        if(tvOnMaterial != null)
        {
            objRenderer.material = tvOnMaterial; // Change to tvOn material when enabled
        }
    }

    private void OnDisable()
    {
        objRenderer.material = defaultMaterial; // Revert back to the original material when disabled
    }
}
