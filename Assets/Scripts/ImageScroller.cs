using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScroller : MonoBehaviour
{
    public List<GameObject> images; // Assign your images in the inspector
    public float displayTime = 2.0f; // Time to display each image
    public int currentImageIndex = 0;

    private void OnEnable()
    {
        // Initially, deactivate all images except the first one
        foreach (var image in images)
        {
            image.SetActive(false);
        }
        images[currentImageIndex].SetActive(true);

        // Start the image cycling coroutine
        StartCoroutine(CycleImages());
    }

    private IEnumerator CycleImages()
    {
        while (true)
        {
            // Wait for the specified display time
            yield return new WaitForSeconds(displayTime);

            // Deactivate the current image
            images[currentImageIndex].SetActive(false);

            // Move to the next image
            currentImageIndex = (currentImageIndex + 1) % images.Count;

            // Activate the next image
            images[currentImageIndex].SetActive(true);
        }
    }
}
