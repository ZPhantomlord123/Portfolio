using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkExperienceController : MonoBehaviour
{
    public List<GameObject> projectScreens;
    private int currentIndex = 0;
    private bool isButtonCooldown = false; // Flag to check if button is on cooldown
    public float buttonCooldownTime = 1f; // Cooldown time in seconds

    private void Start()
    {
        UpdateScreenVisibility();
    }

    public void PreviousScreen()
    {
        if (isButtonCooldown) return; // Exit the function if button is on cooldown

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = projectScreens.Count - 1;
        }

        UpdateScreenVisibility();
        StartCoroutine(ButtonCooldown()); // Start the cooldown
    }

    public void NextScreen()
    {
        if (isButtonCooldown) return; // Exit the function if button is on cooldown

        currentIndex++;
        if (currentIndex >= projectScreens.Count)
        {
            currentIndex = 0;
        }

        UpdateScreenVisibility();
        StartCoroutine(ButtonCooldown()); // Start the cooldown
    }

    private IEnumerator ButtonCooldown()
    {
        isButtonCooldown = true; // Set cooldown flag to true
        yield return new WaitForSeconds(buttonCooldownTime); // Wait for cooldown time
        isButtonCooldown = false; // Reset cooldown flag
    }

    private void UpdateScreenVisibility()
    {
        for (int i = 0; i < projectScreens.Count; i++)
        {
            if (projectScreens[i] != null)
            {
                projectScreens[i].SetActive(i == currentIndex);
            }
        }
    }
}
