using UnityEngine;
using TMPro; // For TextMeshProUGUI
using UnityEngine.EventSystems; // For pointer events

public class HyperlinkButton : MonoBehaviour
{
    public string URL = "http://yourlink.com";
    public TextMeshPro hoverText;
    public string defaultHoverText = "Your default hover text";

    public void OnMouseEnter()
    {
        if (hoverText == null)
            return;
        // Update the TextMeshProUGUI text on hover
        if (hoverText)
        {
            hoverText.text = defaultHoverText; // Update text to indicate clickable link
        }
    }

    public void OnMouseExit()
    {
        if (hoverText == null)
            return;
        // Revert the TextMeshProUGUI text when not hovering
        if (hoverText)
        {
            hoverText.text = ""; // Revert to the default text
        }
    }

    public void OnMouseUp()
    {
        // Open the URL in the default web browser
        Debug.Log("YOOOOOOO");
        Application.OpenURL(URL);
    }
}
