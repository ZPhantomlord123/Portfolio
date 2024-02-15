using UnityEngine;
using UnityEngine.Events;

public class ObjectButton : MonoBehaviour
{
    public Material clickColor;
    private Material originalColor;
    private MeshRenderer textRenderer;

    // Event to trigger camera switch
    public UnityEvent onTextClick;

    private void Start()
    {
        textRenderer = GetComponent<MeshRenderer>();
        originalColor = textRenderer.material;
    }

    private void OnMouseDown()
    {
        textRenderer.material = clickColor;
    }

    private void OnMouseUp()
    {
        textRenderer.material = originalColor;
        onTextClick?.Invoke(); // Trigger the event for camera switch
    }
}
