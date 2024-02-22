using UnityEngine;
using UnityEngine.Events;

public class ObjectButton : MonoBehaviour
{
    public Material clickColor; // Material to apply on click, can be left unassigned.
    private Material originalColor; // Stores the original material of the object.
    private MeshRenderer textRenderer; // Renderer for the 3D text object.

    // Event to trigger camera switch or any other action.
    public UnityEvent onTextClick;

    private void Start()
    {
        textRenderer = GetComponent<MeshRenderer>(); // Get the MeshRenderer component attached to this GameObject.
        originalColor = textRenderer.material; // Store the original material of the object.
    }

    private void OnMouseDown()
    {
        // Apply the clickColor only if it is provided, otherwise, keep the original color.
        if (clickColor != null)
        {
            AudioManager.instance.PlaySoundEffect(SoundEffect.UIClick);
            textRenderer.material = clickColor; // Change the material to clickColor when the mouse button is pressed down.
        }
    }

    private void OnMouseUp()
    {
        textRenderer.material = originalColor; // Revert to the original material when the mouse button is released.
        onTextClick?.Invoke(); // Invoke any actions assigned to the onTextClick UnityEvent.
    }
}
